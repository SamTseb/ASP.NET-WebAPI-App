using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace DBL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Car> cars { get; set; }
        public DbSet<Category> categories { get; set; }

        /// <summary>
        /// For Migrations
        /// </summary> 
        public class EFDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
        {
            public AppDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Store;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DBL"));

                return new AppDBContext(optionsBuilder.Options);
            }
        }

    }
}