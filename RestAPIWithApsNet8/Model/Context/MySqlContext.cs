using Microsoft.EntityFrameworkCore;

namespace RestAPIWithApsNet8.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Books> books { get; set; }
    }
}
