using System.Net.Http.Headers;
using EvolveDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using RestAPIWithApsNet8.Business;
using RestAPIWithApsNet8.Business.Implementations;
using RestAPIWithApsNet8.Configurations;
using RestAPIWithApsNet8.Hypermedia.Enricher;
using RestAPIWithApsNet8.Hypermedia.Filters;
using RestAPIWithApsNet8.Model.Context;
using RestAPIWithApsNet8.Repository;
using RestAPIWithApsNet8.Repository.Generic;
using RestAPIWithApsNet8.Services;
using RestAPIWithApsNet8.Services.Implementations;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var appName = "Rest API's With AspNetCore 8 and Docker";
        var appVersion = "v1";
        var appDescription = $"API Restfull developed '{appName}'";

        // Add services to the container.

        //variaveis para autentications
        var tokenConfigurations = new TokenConfiguration();
        new ConfigureFromConfigurationOptions<TokenConfiguration>(
            builder.Configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

        builder.Services.AddSingleton(tokenConfigurations);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfigurations.Issuer,
                    ValidAudience = tokenConfigurations.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                };
            });

        builder.Services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build());
        });

        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()));

        builder.Services.AddControllers();

        //AddSwagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(appVersion,
                new OpenApiInfo
                {
                    Title = appName,
                    Version = appVersion,
                    Description = appDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Hudney Gomes Nunes",
                        Url = new Uri("https://www.linkedin.com/in/hudney-gomes-nunes/"),

                    }
                });
        });

        //add string de conexão com MySql
        var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];
        builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection,
            new MySqlServerVersion(new Version(8, 0, 3))));

        if (builder.Environment.IsDevelopment())
        {
            MigrateDatabase(connection);
        }

        builder.Services.AddMvc(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            options.FormatterMappings.SetMediaTypeMappingForFormat("Json", MediaTypeHeaderValue.Parse("application/Json").ToString());
            options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
        })
            .AddXmlSerializerFormatters();

        var filterOptions = new HyperMediaFilterOptions();
        filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
        filterOptions.ContentResponseEnricherList.Add(new BooksEnricher());

        builder.Services.AddSingleton(filterOptions);

        //Versionando API
        builder.Services.AddApiVersioning();

        // Dependency Injection 
        builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
        builder.Services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();
        builder.Services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();

        builder.Services.AddTransient<ITokenServices, TokenService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IPersonRepository, PersonRepository>();

        // Dependency Injection for Generics
        builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        // Habilitando CORS
        app.UseCors();

        //Swagger
        app.UseSwagger();

        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appName} - {appVersion}"); });
        var options = new RewriteOptions();
        options.AddRedirect("^$", "swagger");
        app.UseRewriter(options);

        app.UseAuthorization();

        app.MapControllers();

        app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}"); // created today 03/05

        app.Run();

        void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySqlConnection(connection);
                var evolve = new Evolve(evolveConnection, Log.Information)
                {
                    Locations = new List<string> { "db/dataset", "db/migrations" },

                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception e)
            {
                Log.Error("Database Migration failed", e);
                throw;
            }
        }
    }
}