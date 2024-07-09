using SSTHub.Domain.Entities.Interfaces;
using SSTHub.Domain.Enums;

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
        public Roles Role { get; set; }
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public ICollection<Service> Services { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
