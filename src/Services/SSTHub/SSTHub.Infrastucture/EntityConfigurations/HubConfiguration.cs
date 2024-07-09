using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;

namespace SSTHub.Infrastucture.EntityConfigurations
{
    public class HubConfiguration : IEntityTypeConfiguration<Hub>
    {
        public void Configure(EntityTypeBuilder<Hub> builder)
        {
            builder.ToTable("Hubs");
            builder.HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Name)
                .IsUnique();

            builder
                .HasMany(h => h.Events)
                .WithOne(e => e.Hub)
                .HasForeignKey(e => e.HubId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Hub
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 1, 14, 16, 0, 0),
                    Name = "TestHub1",
                    OrganizationId = 1,
                },
                new Hub
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 2, 1, 11, 0, 0),
                    Name = "TestHub2",
                    OrganizationId = 2,
                }
            );
        }
    }
}
