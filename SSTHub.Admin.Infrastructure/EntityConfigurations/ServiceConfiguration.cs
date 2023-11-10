using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Admin.Domain.Entities;

namespace SSTHub.Admin.Infrastructure.EntityConfigurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services"); 

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).HasMaxLength(250);
        builder.Property(s => s.Duration).IsRequired();
        builder.Property(s => s.Price).IsRequired().HasColumnType("decimal(18,2)");
    }
}
