using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL.Database
{
    public class Databasecontext : DbContext
    {
        const string connectionString = "Server=azuredbautomotive.database.windows.net;Database=DotNetCoreAssignemnt;Integrated Security=true;Trusted_Connection=False;Encrypt=True;User ID=LalitAkRadadiya;Password=Gateway123;";
        public Databasecontext() : base() { }

        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserReg> UserRegs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
