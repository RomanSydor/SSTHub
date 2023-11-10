using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Admin.Domain.Entities;

namespace SSTHub.Admin.Infrastructure.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CustomCustomers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.PasswordHash).IsRequired();
        }
    }
}
