using Assesment2DotNet.Model;
using Microsoft.EntityFrameworkCore;

namespace Assesment2DotNet.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options ):base(options) { }
        public DbSet<Employee> employees { get; set; }
    }
}
