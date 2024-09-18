using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastructure.Contexts;
using SSTHub.Infrastructure.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.RepositoryTests
{
    public class HubRepositoryTests
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly HubRepository _hubRepository;
        private readonly HubBuilder _hubBuilder = new();
        private readonly OrganizationBuilder _organizationBuilder = new();

        public HubRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _hubRepository = new HubRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldAddHubToHubsTable()
        {
            //Arrange
            var hub = _hubBuilder.WithDefaultValues();

            //Act
            await _hubRepository.CreateAsync(hub);
            await _sSTHubDbContext.SaveChangesAsync();
            var addedHub = await _hubRepository.GetByIdAsync(hub.Id);

            //Assert
            Assert.NotNull(addedHub);
        }

        [Fact]
        public async Task ShouldGetHubsOfSettedOrganization()
        {
            //Arrange
            var organization1 = _organizationBuilder.WithDefaultValues();
            var organization2 = _organizationBuilder.WithDefaultValues();

            var hub1 = _hubBuilder.WithDefaultValues();
            var hub2 = _hubBuilder.WithDefaultValues();
            var hub3 = _hubBuilder.WithDefaultValues();

            await _sSTHubDbContext.AddRangeAsync(organization1, organization2);
            await _sSTHubDbContext.AddRangeAsync(hub1, hub2, hub3);

            organization1.Hubs.Add(hub1);
            organization1.Hubs.Add(hub2);
            organization2.Hubs.Add(hub3);

            await _sSTHubDbContext.SaveChangesAsync();
            
            //Act
            var organization1Hubs = await _hubRepository.GetByOrganizationIdAsync(organization1.Id);
            var organization2Hubs = await _hubRepository.GetByOrganizationIdAsync(organization2.Id);

            //Assert
            Assert.Equal(2, organization1Hubs.Count);
            Assert.Single(organization2Hubs);
        }
    }
}
