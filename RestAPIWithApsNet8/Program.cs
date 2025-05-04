using System.Net.Http.Headers;
using EvolveDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using RestAPIWithApsNet8.Business;
using RestAPIWithApsNet8.Business.Implementations;
using RestAPIWithApsNet8.Hypermedia.Enricher;
using RestAPIWithApsNet8.Hypermedia.Filters;
using RestAPIWithApsNet8.Model.Context;
using RestAPIWithApsNet8.Repository;
using RestAPIWithApsNet8.Repository.Generic;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
});
    //.AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BooksEnricher());

builder.Services.AddSingleton(filterOptions);

//Versionando API
builder.Services.AddApiVersioning();

// Dependency Injection for Person 
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
//builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

// Dependency Injection for Books 
builder.Services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();
//builder.Services.AddScoped<IBooksRepository, BooksRepositoryImplementation>(); Removed

// Dependency Injection for Generics
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepositoy<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

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
// removed IBookrepositry and BookRepositoryImplementation
