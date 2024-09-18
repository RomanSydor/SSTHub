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
        public async Task ChangeActiveStatusAsync_ForInactiveService_ChangesStatusToActive()
        {
            //Arrange
            var id = 1;
            var employee = _employeeBuilder.WithId(id);

            _mockUnitOfWork
                .EmployeeRepository
                .GetByIdAsync(employee.Id)
                .Returns(employee);

            var employeeService = new EmployeeService(_mockMapper, _mockUnitOfWork, _mockDateTimeService);

            //Act
            await employeeService.ChangeActiveStatusAsync(id);

            //Assert
            Assert.True(employee.IsActive, "IsActive property is not changed");
        }
    }
}
