using Employee_Staff.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Employee_Staff.Data
{
    public class EduCenterDB:DbContext
    {
        private readonly string connectionString = "Server=127.0.0.1; Host=127.0.0.1; Port=5432; User Id=postgres; Password=root; Database=EduCenter;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Staff> Staffs { get; set;}

    }
}
