using Microsoft.EntityFrameworkCore;

namespace StudentApi.Data
{
    public class ApplicatioDbContext : DbContext
    {

        public ApplicatioDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
