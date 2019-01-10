using System;
using System.Collections.Generic;
using System.Text;
using Convice.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class ConviceContext:DbContext
    {
        public ConviceContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Convice;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCategory>().HasKey(u => new {u.UserId , u.CategoryId});
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
    }
}
