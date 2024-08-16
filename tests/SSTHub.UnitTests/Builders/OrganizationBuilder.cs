using SSTHub.Domain.Entities;

namespace SSTHub.UnitTests.Builders
{
    public class OrganizationBuilder
    {
        private Organization _organization;

        public int Id => 0;
        public bool IsActive => false;
        public DateTime CreatedAt => new(2024, 1, 1);
        public string Name => "TestOrg";
        public List<Employee> Employees => new();
        public List<Hub> Hubs => new();

        public OrganizationBuilder() 
        {
            _organization = WithDefaultValues();
        }

        public Organization WithDefaultValues()
        {
            _organization = new Organization
            {
                Id = Id,
                IsActive = IsActive,
                CreatedAt = CreatedAt,
                Name = Name,
                Employees = Employees,
                Hubs = Hubs,
            };

            return _organization;
        }
    }
}
