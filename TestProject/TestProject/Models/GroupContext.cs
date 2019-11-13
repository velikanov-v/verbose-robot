using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Teacher { get; set; }
        public int Number { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int GroupId { get; set; }
        public Team GroupName { get; set; }
       

    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=newdatabase;Trusted_Connection=True;");
        }
    }
}
