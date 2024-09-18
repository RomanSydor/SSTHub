using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;

namespace SSTHub.Infrastructure.EntityConfigurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");
            builder.HasKey(o => o.Id);

            builder
                .HasIndex(o => o.Name)
                .IsUnique();

            builder
                .HasMany(o => o.Hubs)
                .WithOne(h => h.Organization)
                .HasForeignKey(h => h.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(o => o.Employees)
                .WithOne(e => e.Organization)
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Organization
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 1, 14, 16, 0, 0),
                    Name = "TestOrg1",
                },
                new Organization
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 2, 1, 11, 0, 0),
                    Name = "TestOrg2",
                }
            );
        }
    }
}
