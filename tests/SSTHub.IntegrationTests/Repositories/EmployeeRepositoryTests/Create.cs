using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.Repositories.EmployeeRepositoryTests
{
    public class Create
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EmployeeBuilder _employeeBuilder = new();

        public Create()
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
    }
}
