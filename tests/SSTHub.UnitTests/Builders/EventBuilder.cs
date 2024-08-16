using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;

namespace SSTHub.UnitTests.Builders
{
    public class EventBuilder
    {
        private Event _event;

        public int Id => 0;
        public DateTime CreatedAt => new(2024, 1, 1);
        public DateTime StartAt => new(2024, 1, 3);
        public EventStatuses Status => EventStatuses.Created;
        public int CustomerId => 0;
        public int EmployeeId => 0;
        public int HubId => 0;
        public int ServiceId => 0;

        public EventBuilder()
        {
            _event = WithDefaultValues();
        }

        public Event WithDefaultValues()
        {
            _event = new Event
            {
                Id = Id,
                CreatedAt = CreatedAt,
                StartAt = StartAt,
                Status = Status,
                CustomerId = CustomerId,
                EmployeeId = EmployeeId,
                HubId = HubId,
                ServiceId = ServiceId,
            };

            return _event;
        }
    }
}
