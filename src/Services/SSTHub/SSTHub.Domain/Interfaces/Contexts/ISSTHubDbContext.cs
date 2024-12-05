using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces.Contexts
{
    public interface ISSTHubDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>(string name) where TEntity : class;
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(
               TEntity entity,
               CancellationToken cancellationToken = default)
               where TEntity : class;
        Task AddRangeAsync(params object[] entities);
    }
}
