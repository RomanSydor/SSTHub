using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;

namespace SSTHub.Infrastucture.EntityConfigurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Name)
                .IsUnique();

            builder
                .HasMany(s => s.Events)
                .WithOne(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Service
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 14, 16, 0, 0),
                    Name = "TestService1",
                    DurationInMinutes = 60,
                    Price = 100,
                },
                new Service
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 14, 16, 0, 0),
                    Name = "TestService2",
                    DurationInMinutes = 60,
                    Price = 100,
                }
            );
        }
    }
}
