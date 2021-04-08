using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HRM.DAL.Database
{
    public class DatabaseContext : DbContext
    {
        const string connectionString = "Server=azuredbautomotive.database.windows.net;Database=DotNetcore;Integrated Security=true;User ID=LalitAkRadadiya;Password=Gateway123;";
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        
        public DbSet<tblEmployees> tblEmployee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(configuration["ConnectionString:DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEmployees>().Property(e => e.isManager).HasDefaultValue(false);
        }
       
    }
}
