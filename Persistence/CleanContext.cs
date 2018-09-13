using Domain;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence.Employees;
using Persistence.Products;
using Persistence.Sales;

namespace Persistence
{
    public class CleanContext : DbContext
    {
        public CleanContext(DbContextOptions<CleanContext> options) : base (options) {}
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new SaleConfiguration());
        }
    }
}