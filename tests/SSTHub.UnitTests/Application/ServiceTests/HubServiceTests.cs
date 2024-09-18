using AutoMapper;
using NSubstitute;
using SSTHub.Application.Services;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.UnitTests.Builders;

namespace SSTHub.UnitTests.Application.ServiceTests
{
    public class HubServiceTests
    {
        private readonly IUnitOfWork _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IMapper _mockMapper = Substitute.For<IMapper>();
        private readonly IDateTimeService _mockDateTimeService = Substitute.For<IDateTimeService>();
        private readonly HubBuilder _hubBuilder = new();

        [Fact]
        public async Task ChangeActiveStatusAsync_ForInactiveService_ChangesStatusToActive()
        {
            //Arrange
            var id = 1;
            var hub = _hubBuilder.WithId(id);

            _mockUnitOfWork
                .HubRepository
                .GetByIdAsync(hub.Id)
                .Returns(hub);

            var hubService = new HubService(_mockMapper, _mockUnitOfWork, _mockDateTimeService);
            //Act
            await hubService.ChangeActiveStatusAsync(id);

            //Assert
            Assert.True(hub.IsActive, "IsActive property is not changed");
        }
    }
}
