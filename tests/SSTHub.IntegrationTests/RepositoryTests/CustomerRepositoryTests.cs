using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.Contexts;
using SSTHub.Infrastructure.Contexts;
using SSTHub.Infrastructure.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.RepositoryTests
{
    public class CustomerRepositoryTests
    {
        private readonly ISSTHubDbContext _sSTHubDbContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBuilder _customerBuilder = new();
        private readonly HubBuilder _hubBuilder = new();
        private readonly EventBuilder _eventBuilder = new();
        private readonly OrganizationBuilder _organizationBuilder = new();

        public CustomerRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
               .UseInMemoryDatabase(databaseName: "TestSSTHub")
               .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _customerRepository = new CustomerRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldAddCustomerToCustomersTable()
        {
            //Arrange
            var customer = _customerBuilder.WithDefaultValues();

            //Act
            await _customerRepository.CreateAsync(customer);
            await _sSTHubDbContext.SaveChangesAsync();
            var addedCustomer = _sSTHubDbContext
                .Customers
                .Where(c => c.Id == customer.Id)
                .SingleOrDefaultAsync();

            //Assert
            Assert.NotNull(addedCustomer);
        }

        [Fact]
        public async Task ShouldGetCustomersOfSettedHub()
        {
            //Arrange
            var hub1 = _hubBuilder.WithDefaultValues();
            var hub2 = _hubBuilder.WithDefaultValues();

            var event1 = _eventBuilder.WithDefaultValues();
            var event2 = _eventBuilder.WithDefaultValues();
            var event3 = _eventBuilder.WithDefaultValues();

            var customer1 = _customerBuilder.WithDefaultValues();
            var customer2 = _customerBuilder.WithDefaultValues();
            var customer3 = _customerBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(hub1, hub2);
            await _sSTHubDbContext.AddRangeAsync(event1, event2, event3);
            await _sSTHubDbContext.AddRangeAsync(customer1, customer2, customer3);

            hub1.Events.Add(event1);
            hub1.Events.Add(event2);
            hub2.Events.Add(event3);
            customer1.Events.Add(event1);
            customer2.Events.Add(event2);
            customer3.Events.Add(event3);

            await _sSTHubDbContext.SaveChangesAsync();

            //Act
            var hub1Customers = await _customerRepository.GetByHubIdAsync(hub1.Id);
            var hub2Customers = await _customerRepository.GetByHubIdAsync(hub2.Id);

            //Assert
            Assert.Equal(2, hub1Customers.Count);
            Assert.Single(hub2Customers);
        }

        [Fact]
        public async Task ShouldGetCustomersOfSettedOrganization()
        {
            //Arrange
            var organization1 = _organizationBuilder.WithDefaultValues();
            var organization2 = _organizationBuilder.WithDefaultValues();

            var hub1 = _hubBuilder.WithDefaultValues();
            var hub2 = _hubBuilder.WithDefaultValues();

            var event1 = _eventBuilder.WithDefaultValues();
            var event2 = _eventBuilder.WithDefaultValues();
            var event3 = _eventBuilder.WithDefaultValues();

            var customer1 = _customerBuilder.WithDefaultValues();
            var customer2 = _customerBuilder.WithDefaultValues();
            var customer3 = _customerBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(organization1, organization2);
            await _sSTHubDbContext.AddRangeAsync(hub1, hub2);
            await _sSTHubDbContext.AddRangeAsync(event1, event2, event3);
            await _sSTHubDbContext.AddRangeAsync(customer1, customer2, customer3);

            organization1.Hubs.Add(hub1);
            organization2.Hubs.Add(hub2);
            hub1.Events.Add(event1);
            hub1.Events.Add(event2);
            hub2.Events.Add(event3);
            customer1.Events.Add(event1);
            customer2.Events.Add(event2);
            customer3.Events.Add(event3);

            await _sSTHubDbContext.SaveChangesAsync();

            //Act
            var organization1Customers = await _customerRepository.GetByOrganizationIdAsync(organization1.Id);
            var organization2Customers = await _customerRepository.GetByOrganizationIdAsync(organization2.Id);

            //Assert
            Assert.Equal(2, organization1Customers.Count);
            Assert.Single(organization2Customers);
        }
    }
}
