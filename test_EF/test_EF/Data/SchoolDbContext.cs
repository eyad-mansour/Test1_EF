using System;
using Microsoft.EntityFrameworkCore;
using test_EF.Models;

namespace test_EF.Data
{
    public class SchoolDbContext : DbContext
    {
        // this file will make the enitity framework do a map on the object that is decleared in this file and make it like a table in the database 
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technology>().HasData(
                new Technology() { Id = 1, Name = "Javascript" },
                new Technology() { Id = 2, Name = "Advance DotNet Course" },
                new Technology() { Id = 3, Name = "Java Course" }
                );
        }

        public DbSet<Technology>Technologies { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}

