﻿using AutoMapper;
using NSubstitute;
using SSTHub.Application.Services;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.UnitTests.Builders;

namespace SSTHub.UnitTests.Application.ServiceTests
{
    public class ServiceServiceTests
    {
        private readonly IUnitOfWork _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IMapper _mockMapper = Substitute.For<IMapper>();
        private readonly IDateTimeService _mockDateTimeService = Substitute.For<IDateTimeService>();
        private readonly ServiceBuilder _serviceBuilder = new();

        [Fact]
        public async Task ChangeActiveStatusAsync_ForInactiveService_ChangesStatusToActive()
        {
            //Arrange
            var id = 1;
            var service = _serviceBuilder.WithId(id);

            _mockUnitOfWork
                .ServiceRepository
                .GetByIdAsync(service.Id)
                .Returns(service);

            var serviceService = new ServiceService(_mockMapper, _mockUnitOfWork, _mockDateTimeService);
            //Act
            await serviceService.ChangeActiveStatusAsync(id);

            //Assert
            Assert.True(service.IsActive, "IsActive property is not changed");
        }
    }
}
