using Microsoft.EntityFrameworkCore;
using StudentCRUD.Data.DataModel;

namespace StudentCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Student> students { get; set; }

    }
}
