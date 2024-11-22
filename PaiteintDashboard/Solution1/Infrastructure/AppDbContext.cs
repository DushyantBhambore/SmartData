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
    public class AppDbContext : DbContext,IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Pateint> Pateint { get; set; } 
        public DbSet<Countries> Countries { get; set; } 
        public DbSet<States> States { get; set; } 
        public DbSet<Agent> Agent { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Pateint>()
        //              .HasOne(a => a.Agent)
        //              .WithMany(p => p.Patients) // Fix: Changed WithOne to WithMany
        //              .HasForeignKey(p => p.AgentId);

        //    modelBuilder.Entity<Pateint>()
        //        .HasOne(c => c.Country)
        //        .WithMany(p => p.Pateints) // Fix: Changed WithOne to WithMany
        //        .HasForeignKey(p => p.Countries);

        //    modelBuilder.Entity<Pateint>()
        //        .HasOne(s => s.State)
        //        .WithMany(p => p.Pateints) // Fix: Changed WithOne to WithMany
        //        .HasForeignKey(s => s.States);
           

        //    base.OnModelCreating(modelBuilder);

        //}
    }


}
