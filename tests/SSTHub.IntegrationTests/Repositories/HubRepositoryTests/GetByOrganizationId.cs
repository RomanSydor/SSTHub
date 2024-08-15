using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.Repositories.HubRepositoryTests
{
    public class GetByOrganizationId
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly HubRepository _hubRepository;
        private readonly HubBuilder _hubBuilder = new();

        public GetByOrganizationId()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _hubRepository = new HubRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldGetHubsOfSettedOrganization()
        {
            //Arrange
            var organizationId = 1;
            var hub1 = _hubBuilder.WithOrganizationId(1);
            var hub2 = _hubBuilder.WithOrganizationId(2);
            var hub3 = _hubBuilder.WithOrganizationId(1);
            var hub4 = _hubBuilder.WithOrganizationId(2);

            //Act
            await _sSTHubDbContext.AddRangeAsync(hub1, hub2, hub3, hub4);
            await _sSTHubDbContext.SaveChangesAsync();

            var hubs = await _hubRepository.GetByOrganizationIdAsync(organizationId);
            var count = hubs
                .Where(h => h.OrganizationId != organizationId)
                .Count();

            //Assert
            Assert.Equal(0, count);
        }
    }
}
