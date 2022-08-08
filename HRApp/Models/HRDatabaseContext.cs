using Microsoft.EntityFrameworkCore;
using HRApp.Models;
namespace HRApp.Models
{
    public class HRDatabaseContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
    //"DefaultConnection": "Data Source=.;Initial Catalog=Bulky;Integrated Security=True"
            //
            optionsBuilder.UseSqlServer(@"Server=.;Database=HRDB;Integrated Security=True");
        }

    }
}
