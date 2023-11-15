using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;

namespace SSTHub.Infrastructure.EntityConfigurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events"); 

        builder.HasKey(e => e.Id);


        builder.Property(e => e.CustomerId).IsRequired();
        builder.Property(e => e.EmployeeId).IsRequired();
        builder.Property(e => e.BarbershopId).IsRequired();
        builder.Property(e => e.ServiceId).IsRequired();
        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.Status).IsRequired();
    }
}