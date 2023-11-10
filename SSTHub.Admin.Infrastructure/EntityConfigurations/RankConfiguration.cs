using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Admin.Domain.Entities;

namespace SSTHub.Admin.Infrastructure.EntityConfigurations;

public class RankConfiguration : IEntityTypeConfiguration<Rank>
{
    public void Configure(EntityTypeBuilder<Rank> builder)
    {
        builder.ToTable("EmployeesRanks");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(r => r.Premium)
            .HasColumnType("decimal(18,2)");
    }
}
