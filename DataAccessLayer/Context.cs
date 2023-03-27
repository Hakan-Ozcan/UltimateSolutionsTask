using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context:DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AEUI2LS;Database=AcceptOrderDb;Trusted_Connection=True;TrustServerCertificate=True",
               b => b.MigrationsAssembly("DataAccessLayer"));

          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(b => b.Id).IsRequired();

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
