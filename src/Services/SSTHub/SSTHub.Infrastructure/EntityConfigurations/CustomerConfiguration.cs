using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;

namespace SSTHub.Infrastructure.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);

            builder
                .HasMany(c => c.Events)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Customer
                {
                    Id = 1,
                    CreatedAt = new DateTime(2024, 1, 16, 16, 0, 0),
                    FirstName = "Roman",
                    LastName = "Aaaa",
                    Email = "testRA@test.com",
                    Phone = "1111111111",
                },
                new Customer
                {
                    Id = 2,
                    CreatedAt = new DateTime(2024, 1, 14, 16, 0, 0),
                    FirstName = "Ivan",
                    LastName = "BBBB",
                    Email = "testIB@test.com",
                    Phone = "2222222222",
                }
            );
        }
    }
}
