using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Infrastucture.EntityConfigurations;

namespace SSTHub.Infrastucture.Contexts
{
    public class SSTHubDbContext : DbContext
    {
        public SSTHubDbContext(DbContextOptions<SSTHubDbContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HubConfiguration).Assembly);
        }

    }
}
