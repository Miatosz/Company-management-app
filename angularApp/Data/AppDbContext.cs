using angularApp.Models;
using Microsoft.EntityFrameworkCore;

namespace angularApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments {get; set;}
        public DbSet<Employee> Employess { get; set; }
   
    
   
    }

}