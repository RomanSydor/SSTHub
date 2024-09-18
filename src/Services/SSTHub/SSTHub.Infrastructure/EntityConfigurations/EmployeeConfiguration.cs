using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;

namespace SSTHub.Infrastructure.EntityConfigurations
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

            builder
                .HasMany(e => e.Services)
                .WithMany(s => s.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeService",
                    r => r.HasOne<Service>().WithMany().HasForeignKey("ServicesId"),
                    l => l.HasOne<Employee>().WithMany().HasForeignKey("EmployeesId"),
                    je =>
                    {
                        je.HasKey("EmployeesId", "ServicesId");
                        je.HasData(
                            new { EmployeesId = 1, ServicesId = 1},
                            new { EmployeesId = 1, ServicesId = 2},
                            new { EmployeesId = 2, ServicesId = 1},
                            new { EmployeesId = 2, ServicesId = 2}
                        );
                    }
                );

            builder
                .HasMany(e => e.Events)
                .WithOne(ev => ev.Employee)
                .HasForeignKey(ev => ev.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Employee
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 8, 25, 10, 0, 0),
                    FirstName = "Dmytro",
                    LastName = "Watson",
                    Email = "testDW@test.com",
                    Phone = "1231231231",
                    Role = Roles.OrganizationAdmin,
                    OrganizationId = 1,
                },
                new Employee
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 2, 15, 0, 0),
                    FirstName = "Petro",
                    LastName = "Abc",
                    Email = "testPA@test.com",
                    Phone = "43434343433",
                    Role = Roles.OrganizationAdmin,
                    OrganizationId = 2,
                },
                new Employee
                {
                    Id = 3,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 2, 15, 0, 0),
                    FirstName = "Alex",
                    LastName = "Test",
                    Email = "testAT@test.com",
                    Phone = "43433343433",
                    Role = Roles.HubAdmin,
                    OrganizationId = 1,
                },
                new Employee
                {
                    Id = 4,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 2, 15, 0, 0),
                    FirstName = "Rob",
                    LastName = "Test",
                    Email = "testRT@test.com",
                    Phone = "43433343513",
                    Role = Roles.HubAdmin,
                    OrganizationId = 2,
                },
                new Employee
                {
                    Id = 5,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 2, 15, 0, 0),
                    FirstName = "Sam",
                    LastName = "Test",
                    Email = "testST@test.com",
                    Phone = "43433343213",
                    Role = Roles.Specialist,
                    OrganizationId = 1,
                },
                new Employee
                {
                    Id = 6,
                    IsActive = true,
                    CreatedAt = new DateTime(2023, 12, 2, 15, 0, 0),
                    FirstName = "John",
                    LastName = "Test",
                    Email = "testJT@test.com",
                    Phone = "43466643513",
                    Role = Roles.Specialist,
                    OrganizationId = 2,
                }
            );
        }
    }
}
