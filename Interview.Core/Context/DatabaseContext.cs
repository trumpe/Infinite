using Interview.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .Property(b => b.Created)
                .HasDefaultValueSql("getdate()");
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            var connectionString = @"Server=localhost\SQLEXPRESS;Database=interview;Trusted_Connection=True;";           
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.EnableSensitiveDataLogging(true);
        }

        ~DatabaseContext()
        {
            Dispose();
        }

    }
}
