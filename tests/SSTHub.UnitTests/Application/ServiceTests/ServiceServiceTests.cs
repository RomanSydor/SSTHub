using AutoMapper;
using NSubstitute;
using SSTHub.Application.Services;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.UnitTests.Builders;

namespace SSTHub.UnitTests.Application.ServiceTests
{
    public class ServiceServiceTests
    {
        private readonly IUnitOfWork _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IMapper _mockMapper = Substitute.For<IMapper>();
        private readonly ServiceBuilder _serviceBuilder = new();

        [Fact]
        public async Task ShouldChangeServiceIsActivePropertyAsync()
        {
            //Arrange
            var service = _serviceBuilder.WithDefaultValues();

            _mockUnitOfWork.ServiceRepository.GetByIdAsync(service.Id).Returns(service);

            var serviceService = new ServiceService(_mockMapper, _mockUnitOfWork);
            //Act
            await serviceService.ChangeActiveStatusAsync(1);

            //Assert
            Assert.True(service.IsActive, "IsActive property is not chenged");
        }
    }
}
