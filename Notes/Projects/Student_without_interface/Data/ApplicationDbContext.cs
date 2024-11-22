using Microsoft.EntityFrameworkCore;
using Student_without_interface.Model;

namespace Student_without_interface.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Student> students { get; set; }
    }
}
