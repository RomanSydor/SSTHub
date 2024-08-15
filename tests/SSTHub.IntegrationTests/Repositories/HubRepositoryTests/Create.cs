using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.Repositories.HubRepositoryTests
{
    public class Create
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly HubRepository _hubRepository;
        private readonly HubBuilder _hubBuilder = new();

        public Create()
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
    }
}
