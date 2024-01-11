using SSTHub.Domain.Entities.Enums;
using SSTHub.Domain.Entities.Interfaces;

namespace SSTHub.Domain.Entities
{
    public class Event : IEntity, IActivatable
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartAt { get; set; }
        public EventStatuses Status { get; set; }
    }
}
