using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.RepositoryTests
{
    public class EmployeeRepositoryTests
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EmployeeBuilder _employeeBuilder = new();
        private readonly OrganizationBuilder _organizationBuilder = new();

        public EmployeeRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _employeeRepository = new EmployeeRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldAddEmployeeToEmployeesTable()
        {
            //Arrange
            var employee = _employeeBuilder.WithDefaultValues();

            //Act
            await _employeeRepository.CreateAsync(employee);
            await _sSTHubDbContext.SaveChangesAsync();
            var addedEmployee = await _employeeRepository.GetByIdAsync(employee.Id);

            //Assert
            Assert.NotNull(addedEmployee);
        }

        [Fact]
        public async Task ShouldGetEmployeesOfSettedOrganization()
        {
            //Arrange
            var organization1 = _organizationBuilder.WithDefaultValues();
            var organization2 = _organizationBuilder.WithDefaultValues();

            var employee1 = _employeeBuilder.WithDefaultValues();
            var employee2 = _employeeBuilder.WithDefaultValues();
            var employee3 = _employeeBuilder.WithDefaultValues();
            var employee4 = _employeeBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(organization1, organization2);
            await _sSTHubDbContext.AddRangeAsync(employee1, employee2, employee3, employee4);

            organization1.Employees.Add(employee1); 
            organization1.Employees.Add(employee2); 
            organization1.Employees.Add(employee3); 
            organization2.Employees.Add(employee4); 
            
            await _sSTHubDbContext.SaveChangesAsync();

            //Act
            var organization1Employees = await _employeeRepository.GetByOrganizationIdAsync(organization1.Id);
            var organization2Employees = await _employeeRepository.GetByOrganizationIdAsync(organization2.Id);

            //Assert
            Assert.Equal(3, organization1Employees.Count);
            Assert.Single(organization2Employees);
        }
    }
}
