using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastructure.Contexts;
using SSTHub.Infrastructure.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.RepositoryTests
{
    public class ServiceRepositoryTests
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly ServiceRepository _serviceRepository;
        private readonly ServiceBuilder _serviceBuilder = new();
        private readonly EmployeeBuilder _employeeBuilder = new();
        private readonly OrganizationBuilder _organizationBuilder = new();

        public ServiceRepositoryTests() 
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _serviceRepository = new ServiceRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldAddServiceToServicesTable()
        {
            //Arrange
            var service = _serviceBuilder.WithDefaultValues();

            //Act
            await _serviceRepository.CreateAsync(service);
            await _sSTHubDbContext.SaveChangesAsync();
            var addedService = await _serviceRepository.GetByIdAsync(service.Id);

            //Assert
            Assert.NotNull(addedService);
        }

        [Fact]
        public async Task ShouldGetServicesOfSettedEmployee()
        {
            //Arrange
            var employee1 = _employeeBuilder.WithDefaultValues();
            var employee2 = _employeeBuilder.WithDefaultValues();

            var service1 = _serviceBuilder.WithDefaultValues();
            var service2 = _serviceBuilder.WithDefaultValues();
            var service3 = _serviceBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(employee1, employee2);
            await _sSTHubDbContext.AddRangeAsync(service1, service2, service3);

            employee1.Services.Add(service1);
            employee1.Services.Add(service2);
            employee2.Services.Add(service3);

            await _sSTHubDbContext.SaveChangesAsync();

            //Act
            var employee1Services = await _serviceRepository.GetByEmployeeIdAsync(employee1.Id);
            var employee2Services = await _serviceRepository.GetByEmployeeIdAsync(employee2.Id);

            //Assert
            Assert.Equal(2, employee1Services.Count);
            Assert.Single(employee2Services);
        }

        [Fact]
        public async Task ShouldGetServicesOfSettedOrganization()
        {
            //Arrange
            var organization1 = _organizationBuilder.WithDefaultValues();
            var organization2 = _organizationBuilder.WithDefaultValues();

            var employee1 = _employeeBuilder.WithDefaultValues();
            var employee2 = _employeeBuilder.WithDefaultValues();

            var service1 = _serviceBuilder.WithDefaultValues();
            var service2 = _serviceBuilder.WithDefaultValues();
            var service3 = _serviceBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(organization1, organization2);
            await _sSTHubDbContext.AddRangeAsync(employee1, employee2);
            await _sSTHubDbContext.AddRangeAsync(service1, service2, service3);

            organization1.Employees.Add(employee1);
            organization2.Employees.Add(employee2);
            employee1.Services.Add(service1);
            employee1.Services.Add(service2);
            employee2.Services.Add(service3);

            await _sSTHubDbContext.SaveChangesAsync();

            //Act 
            var organization1Services = await _serviceRepository.GetByOrganizationIdAsync(organization1.Id);
            var organization2Services = await _serviceRepository.GetByOrganizationIdAsync(organization2.Id);

            //Assert
            Assert.Equal(2, organization1Services.Count);
            Assert.Single(organization2Services);
        }
    }
}
