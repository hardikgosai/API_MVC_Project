using Getri_API_MVC_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Getri_API_MVC_Project.EntityFramework
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
