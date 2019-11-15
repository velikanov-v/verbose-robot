using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondProject.Models;

namespace SecondProject.Models
{
    public class ApplicContext:DbContext
    {
        public ApplicContext(DbContextOptions<ApplicContext> options) : base(options)
        {
            //Database.EnsureDeleted;
            //Database.EnsureCreated;
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Organisation> Organisation { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<GroupsWorkers> GroupsWorkers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupsWorkers>()
            .HasKey(t => new { t.WorkerId, t.GroupId });
            
            modelBuilder.Entity<GroupsWorkers>()
           .HasOne(sc => sc.Worker)
           .WithMany(s => s.GroupWorkers)
           .HasForeignKey(sc => sc.WorkerId); 

            modelBuilder.Entity<GroupsWorkers>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.GroupWorkers)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<Organisation>()
           .HasOne(p => p.Teacher)
           .WithMany(t => t.Organisations)
           .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Group>()
         .HasOne(p => p.Teacher)
         .WithMany(t => t.Groups)
         .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
