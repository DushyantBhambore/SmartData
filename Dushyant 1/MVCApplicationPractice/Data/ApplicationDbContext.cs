using Microsoft.EntityFrameworkCore;
using MVCApplicationPractice.Data.DataModel;

namespace MVCApplicationPractice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CRUD> cRUDs { get; set; }
        public DbSet<Register> registers { get; set; }
    }
}
