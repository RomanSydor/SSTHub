using Microsoft.EntityFrameworkCore;
using SSTHub.Admin.Domain.Entities;
using System.Reflection;

namespace SSTHub.Admin.Infrastructure.Contexts;

public class SSTHubDbContext : DbContext
{
    public DbSet<Barbershop> Barbershops { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Rank> Ranks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
