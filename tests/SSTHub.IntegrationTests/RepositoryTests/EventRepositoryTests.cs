using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.Contexts;
using SSTHub.Infrastructure.Contexts;
using SSTHub.Infrastructure.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.RepositoryTests
{
    public class EventRepositoryTests
    {
        private readonly ISSTHubDbContext _sSTHubDbContext;
        private readonly IEventRepository _eventRepository;
        private readonly EventBuilder _eventBuilder = new();
        private readonly HubBuilder _hubBuilder = new();
        private readonly OrganizationBuilder _organizationBuilder = new();

        public EventRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _eventRepository = new EventRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldAddEventToEventsTable()
        {
            //Arrange
            var @event = _eventBuilder.WithDefaultValues();

            //Act
            await _eventRepository.CreateAsync(@event);
            await _sSTHubDbContext.SaveChangesAsync();
            var addedEvent = await _eventRepository.GetByIdAsync(@event.Id);

            //Assert
            Assert.NotNull(addedEvent);
        }

        [Fact]
        public async Task ShouldGetEventsOfSettedHub()
        {
            //Arrange
            var hub1 = _hubBuilder.WithDefaultValues();
            var hub2 = _hubBuilder.WithDefaultValues();

            var event1 = _eventBuilder.WithDefaultValues();
            var event2 = _eventBuilder.WithDefaultValues();
            var event3 = _eventBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(hub1, hub2);
            await _sSTHubDbContext.AddRangeAsync(event1, event2, event3);

            hub1.Events.Add(event1);
            hub1.Events.Add(event2);
            hub2.Events.Add(event3);

            await _sSTHubDbContext.SaveChangesAsync();

            //Act
            var hub1Events = await _eventRepository.GetByHubIdAsync(hub1.Id);
            var hub2Events = await _eventRepository.GetByHubIdAsync(hub2.Id);

            //Assert
            Assert.Equal(2, hub1Events.Count);
            Assert.Single(hub2Events);
        }

        [Fact]
        public async Task ShouldGetEventsOfSettedOrganization()
        {
            //Arrange
            var organization1 = _organizationBuilder.WithDefaultValues();
            var organization2 = _organizationBuilder.WithDefaultValues();

            var hub1 = _hubBuilder.WithDefaultValues();
            var hub2 = _hubBuilder.WithDefaultValues();

            var event1 = _eventBuilder.WithDefaultValues();
            var event2 = _eventBuilder.WithDefaultValues();
            var event3 = _eventBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(organization1, organization2);
            await _sSTHubDbContext.AddRangeAsync(hub1, hub2);
            await _sSTHubDbContext.AddRangeAsync(event1, event2, event3);

            organization1.Hubs.Add(hub1);
            organization2.Hubs.Add(hub2);
            hub1.Events.Add(event1);
            hub1.Events.Add(event2);
            hub2.Events.Add(event3);

            await _sSTHubDbContext.SaveChangesAsync();

            //Act
            var organization1Events = await _eventRepository.GetByOrganizationIdAsync(organization1.Id);
            var organization2Events = await _eventRepository.GetByOrganizationIdAsync(organization2.Id);

            //Assert
            Assert.Equal(2, organization1Events.Count);
            Assert.Single(organization2Events);
        }
    }
}
