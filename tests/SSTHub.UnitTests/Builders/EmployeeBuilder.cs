using SSTHub.Domain.Entities;

namespace SSTHub.UnitTests.Builders
{
    public class EmployeeBuilder
    {
        private Employee _employee;

        public int Id => 0;
        public bool IsActive => false;
        public DateTime CreatedAt => new(2024, 1, 1);
        public string FirstName => "TestName";
        public string LastName => "TestLN";
        public string Email => "test@test.com";
        public string Phone => "0993254565";
        public int OrganizationId => 0;
        public List<Service> Services => new();

        public EmployeeBuilder()
        {
            _employee = WithDefaultValues();
        }

        public Employee WithDefaultValues()
        {
            _employee = new Employee
            {
                Id = Id,
                IsActive = IsActive,
                CreatedAt = CreatedAt,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                OrganizationId = OrganizationId,
                Services = Services,
            };

            return _employee;
        }

        public Employee WithId(int id)
        {
            var employee = WithDefaultValues();
            employee.Id = id;
            return employee;
        }
    }
}
