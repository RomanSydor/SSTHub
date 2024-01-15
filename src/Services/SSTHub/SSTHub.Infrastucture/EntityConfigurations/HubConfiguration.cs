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
                .HasMany(h => h.Employees)
                .WithOne(e => e.Hub)
                .HasForeignKey(e => e.HubId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(h => h.Events)
                .WithOne(e => e.Hub)
                .HasForeignKey(e => e.HubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
