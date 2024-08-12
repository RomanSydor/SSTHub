using AutoMapper;
using NSubstitute;
using SSTHub.Application.Services;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.UnitTests.Builders;

namespace SSTHub.UnitTests.Application.ServiceTests
{
    public class HubServiceTests
    {
        private readonly IUnitOfWork _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IMapper _mockMapper = Substitute.For<IMapper>();
        private readonly HubBuilder _hubBuilder = new();

        [Fact]
        public async Task ShouldChangeHubIsActivePropertyAsync()
        {
            //Arrange
            var hub = _hubBuilder.WithDefaultValues();

            _mockUnitOfWork
                .HubRepository
                .GetByIdAsync(hub.Id)
                .Returns(hub);

            var hubService = new HubService(_mockMapper, _mockUnitOfWork);
            //Act
            await hubService.ChangeActiveStatusAsync(1);

            //Assert
            Assert.True(hub.IsActive, "IsActive property is not chenged");
        }
    }
}
