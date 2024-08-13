using AutoMapper;
using NSubstitute;
using SSTHub.Application.Services;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.UnitTests.Builders;

namespace SSTHub.UnitTests.Application.ServiceTests
{
    public class EmployeeServiceTests
    {
        private readonly IUnitOfWork _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IMapper _mockMapper = Substitute.For<IMapper>();
        private readonly IDateTimeService _mockDateTimeService = Substitute.For<IDateTimeService>();
        private readonly EmployeeBuilder _employeeBuilder = new();

        [Fact]
        public async Task ShouldChangeEmployeeIsActivePropertyAsync()
        {
            //Arrange
            var employee = _employeeBuilder.WithDefaultValues();

            _mockUnitOfWork
                .EmployeeRepository
                .GetByIdAsync(employee.Id)
                .Returns(employee);

            var employeeService = new EmployeeService(_mockMapper, _mockUnitOfWork, _mockDateTimeService);

            //Act
            await employeeService.ChangeActiveStatusAsync(1);

            //Assert
            Assert.True(employee.IsActive, "IsActive property is not chenged");
        }
    }
}
