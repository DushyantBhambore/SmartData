using App.core.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext ,IAppDBContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employee { get; set; }

    public DbSet<Customers> Customer { get; set; }

      public DbSet<Pateints> Pateint { get; set; }

        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
     


    }

}
