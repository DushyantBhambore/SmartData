using App.Core.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infreatsructure
{
    public class AppDbContext : DbContext, IAppDbcontext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext):base(dbContext)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Otp> Otp { get; set; }


    }
}
