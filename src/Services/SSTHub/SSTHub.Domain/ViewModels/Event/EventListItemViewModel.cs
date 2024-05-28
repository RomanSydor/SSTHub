using SSTHub.Domain.Enums;

namespace SSTHub.Domain.ViewModels.Event
{
    public class EventListItemViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartAt { get; set; }
        public EventStatuses Status { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
    }
}
