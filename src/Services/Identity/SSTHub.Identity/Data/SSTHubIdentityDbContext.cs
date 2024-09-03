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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>()
                .HasData(
                    new IdentityRole<int>
                    {
                        Id = 1,
                        Name = "OrganizationAdmin",
                        NormalizedName = "ORGANIZATIONADMIN",
                    }
                );

            base.OnModelCreating(builder);
        }
    }
}
