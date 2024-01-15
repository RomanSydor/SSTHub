using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;

namespace SSTHub.Infrastucture.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Email)
                .IsUnique();

            builder
                .HasIndex(e => e.Phone)
                .IsUnique();

            builder
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            //builder
            //    .HasMany(e => e.Services)
            //    .WithOne(s => s.Employee)
            //    .HasForeignKey(s => s.EmployeeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Events)
                .WithOne(ev => ev.Employee)
                .HasForeignKey(ev => ev.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
