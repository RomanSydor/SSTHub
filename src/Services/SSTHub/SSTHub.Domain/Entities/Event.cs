using SSTHub.Domain.Entities.Interfaces;
using SSTHub.Domain.Enums;

namespace SSTHub.Domain.Entities
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartAt { get; set; }
        public EventStatuses Status { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int HubId { get; set; }
        public int ServiceId { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Hub Hub { get; set; }
        public Service Service { get; set; }
    }
}
