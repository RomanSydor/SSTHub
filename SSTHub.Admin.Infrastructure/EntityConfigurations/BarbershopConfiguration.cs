using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SSTHub.Admin.Domain.Entities;

namespace SSTHub.Admin.Infrastructure.EntityConfigurations;

public class BarbershopConfiguration : IEntityTypeConfiguration<Barbershop>
{
    public void Configure(EntityTypeBuilder<Barbershop> builder)
    {
        builder.ToTable("Barbershops"); 

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Description).HasMaxLength(250);
        builder.Property(b => b.Location).IsRequired().HasMaxLength(100);

    }
}

