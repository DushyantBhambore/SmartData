
using CRUDApplication.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options ):base (options)
        {
        }

        public DbSet<Pateint> pateints { get; set; }
        public DbSet<Provider> providers { get; set; }
    }
}
