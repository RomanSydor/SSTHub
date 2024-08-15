using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;

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
        public int OrganizationId => 1;

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
            };

            return _employee;
        }

        public Employee WithId(int id)
        {
            _employee.Id = id;
            return _employee;
        }

        public Employee WithOrganizationId(int id) 
        {
            _employee.OrganizationId = id;
            return _employee;
        }

        public Employee OrganizationAdminWithDefaultValues()
        {
            _employee.Role = Roles.OrganizationAdmin;
            return _employee;
        }
        
        public Employee HubAdminWithDefaultValues()
        {
            _employee.Role = Roles.HubAdmin;
            return _employee;
        }

        public Employee SpecialistWithDefaultValues()
        {
            _employee.Role = Roles.Specialist;
            return _employee;
        }
    }
}
