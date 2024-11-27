using App.Core.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Practitioner> Practitioner { get; set; }
        public DbSet<OTP> Otp { get; set; }
    }
}
