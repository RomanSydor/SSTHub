using SSTHub.Domain.Entities.Enums;
using SSTHub.Domain.Entities.Interfaces;

namespace SSTHub.Domain.Entities
{
    public class Employee : IEntity, IActivatable
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EmployeePositions Position { get; set; }
    }
}
