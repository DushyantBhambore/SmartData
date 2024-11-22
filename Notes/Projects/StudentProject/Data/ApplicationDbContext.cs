using Microsoft.EntityFrameworkCore;
using StudentProject.Model;

namespace StudentProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options ): base(options) { }
        
        public DbSet<PateinltsModel> pateints { get; set; }
    }
}
