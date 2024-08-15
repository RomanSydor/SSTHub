using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.Repositories.EmployeeRepositoryTests
{
    public class GetByOrganizationId
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EmployeeBuilder _employeeBuilder = new();

        public GetByOrganizationId()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _employeeRepository = new EmployeeRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldGetEmployeesOfSettedOrganization()
        {
            //Arrange
            var organizationId = 1;
            var employee1 = _employeeBuilder.WithOrganizationId(1);
            var employee2 = _employeeBuilder.WithOrganizationId(2);
            var employee3 = _employeeBuilder.WithOrganizationId(1);
            var employee4 = _employeeBuilder.WithOrganizationId(2);

            //Act
            await _sSTHubDbContext.AddRangeAsync(employee1, employee2 , employee3 , employee4 );
            await _sSTHubDbContext.SaveChangesAsync();

            var employees = await _employeeRepository.GetByOrganizationIdAsync(organizationId);
            var count = employees
                .Where(e => e.OrganizationId != organizationId)
                .Count();

            //Assert
            Assert.Equal(0, count);
        }
    }
}
