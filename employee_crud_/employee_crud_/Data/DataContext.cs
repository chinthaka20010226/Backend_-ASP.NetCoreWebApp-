using employee_crud_.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_crud_.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
