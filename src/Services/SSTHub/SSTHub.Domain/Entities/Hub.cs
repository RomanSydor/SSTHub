using SSTHub.Domain.Entities.Interfaces;

namespace SSTHub.Domain.Entities
{
    public class Hub : IEntity, IActivatable
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
