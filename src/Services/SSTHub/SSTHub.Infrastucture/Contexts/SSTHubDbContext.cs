using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;
using SSTHub.Infrastucture.EntityConfigurations;

namespace SSTHub.Infrastucture.Contexts
{
    public class SSTHubDbContext : DbContext
    {
        public SSTHubDbContext(DbContextOptions<SSTHubDbContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HubConfiguration).Assembly);

            modelBuilder.Entity<Hub>().HasData(
                new Hub
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    Name= "TestHub1",
                },
                new Hub
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    Name = "TestHub2",
                }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    Name = "TestService1",
                    DurationInMinutes = 60,
                    Price = 100,
                },
                new Service
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    Name = "TestService2",
                    DurationInMinutes = 60,
                    Price = 100,
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    FirstName = "Roman",
                    LastName = "Aaaa",
                    Email = "testRA@test.com",
                    Phone = "1111111111",
                },
                new Customer
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    FirstName = "Ivan",
                    LastName = "BBBB",
                    Email = "testIB@test.com",
                    Phone = "2222222222",
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    FirstName = "Dmytro",
                    LastName = "Watson",
                    Email = "testDW@test.com",
                    Phone = "1231231231",
                    Position = EmployeePositions.Administrator,
                    HubId = 1,
                },
                new Employee
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    FirstName = "Petro",
                    LastName = "Abc",
                    Email = "testPA@test.com",
                    Phone = "43434343433",
                    Position = EmployeePositions.Barber,
                    HubId = 2,
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(1),
                    Status = EventStatuses.Created,
                    CustomerId = 1,
                    EmployeeId = 1,
                    HubId = 1,
                    ServiceId = 1,
                },
                new Event
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(-1),
                    Status = EventStatuses.Finished,
                    CustomerId = 2,
                    EmployeeId = 2,
                    HubId = 2,
                    ServiceId = 2,
                }
            );
        }

    }
}
