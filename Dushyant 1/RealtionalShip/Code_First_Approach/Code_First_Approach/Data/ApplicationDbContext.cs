using Code_First_Approach.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Code_First_Approach.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Instructors> instructors { get; set; }
        public DbSet<Courses> courses { get; set; }

    }
}
