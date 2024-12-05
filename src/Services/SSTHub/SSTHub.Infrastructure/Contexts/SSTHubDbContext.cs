using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces.Contexts;
using SSTHub.Infrastructure.EntityConfigurations;

namespace SSTHub.Infrastructure.Contexts
{
    public class SSTHubDbContext : DbContext, ISSTHubDbContext
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
        public DbSet<Organization> Organizations {  get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HubConfiguration).Assembly);
        }

    }
}
