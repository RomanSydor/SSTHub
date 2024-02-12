using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSTHub.Identity.Models.Entities;

namespace SSTHub.Identity.Data
{
    public class SSTHubIdentityDbContext : IdentityDbContext<EmployeeUser, IdentityRole<int>, int>
    {
        public SSTHubIdentityDbContext(DbContextOptions<SSTHubIdentityDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Position>()
                .ToTable("Positions")
                .HasMany(p => p.EmployeeUsers)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EmployeeUser>()
                .Property(e => e.PositionId)
                .IsRequired(false);

            builder.Entity<IdentityRole<int>>()
                .HasData(
                    new IdentityRole<int>
                    {
                        Id = 1,
                        Name = "HubAdmin",
                    },
                    new IdentityRole<int>
                    {
                        Id = 2,
                        Name = "Employee",
                    }
                );

            base.OnModelCreating(builder);
        }
    }
}
