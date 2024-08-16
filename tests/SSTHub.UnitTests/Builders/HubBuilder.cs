using SSTHub.Domain.Entities;

namespace SSTHub.UnitTests.Builders
{
    public class HubBuilder
    {
        private Hub _hub;

        public int Id => 0;
        public bool IsActive => false;
        public DateTime CreatedAt => new(2024, 1, 1);
        public string Name => "TestHub";
        public int OrganizationId => 0;

        public HubBuilder()
        {
            _hub = WithDefaultValues();
        }

        public Hub WithDefaultValues()
        {
            _hub = new Hub
            {
                Id = Id,
                IsActive = IsActive,
                CreatedAt = CreatedAt,
                Name = Name, 
                OrganizationId = OrganizationId,
            };

            return _hub;
        }

        public Hub WithId(int id)
        {
            var hub = WithDefaultValues();
            hub.Id = id;
            return hub;
        }
    }
}
