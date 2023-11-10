using SSTHub.Admin.Domain.Common.Enums;

namespace SSTHub.Admin.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }
    
    public Guid CustomerId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid BarbershopId { get; set; }

    public Guid ServiceId { get; set; }

    public DateTime StartDate { get; set; }

    public Status Status { get; set; }
}
