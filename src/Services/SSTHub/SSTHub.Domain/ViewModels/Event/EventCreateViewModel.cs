namespace SSTHub.Domain.ViewModels.Event
{
    public class EventCreateViewModel
    {
        public DateTime StartAt { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int HubId { get; set; }
        public int ServiceId { get; set; }
    }
}
