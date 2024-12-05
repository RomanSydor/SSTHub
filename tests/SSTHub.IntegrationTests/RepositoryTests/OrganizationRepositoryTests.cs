using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.Contexts;
using SSTHub.Infrastructure.Contexts;
using SSTHub.Infrastructure.Repositories;
using SSTHub.UnitTests.Builders;

namespace SSTHub.IntegrationTests.RepositoryTests
{
    public class OrganizationRepositoryTests
    {
        private readonly ISSTHubDbContext _sSTHubDbContext;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationBuilder _organizationBuilder = new();

        public OrganizationRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<SSTHubDbContext>()
                .UseInMemoryDatabase(databaseName: "TestSSTHub")
                .Options;
            _sSTHubDbContext = new SSTHubDbContext(dbOptions);
            _organizationRepository = new OrganizationRepository(_sSTHubDbContext);
        }

        [Fact]
        public async Task ShouldAddOrganizationToOrganizationsTable()
        {
            //Arrange
            var organization = _organizationBuilder.WithDefaultValues();

            //Act
            await _organizationRepository.CreateAsync(organization);
            await _sSTHubDbContext.SaveChangesAsync();
            var addedOrganization = await _organizationRepository.GetByIdAsync(organization.Id);

            //Assert
            Assert.NotNull(addedOrganization);
        }
    }
}
