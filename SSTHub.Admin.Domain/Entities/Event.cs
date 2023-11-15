using SSTHub.Domain.Common.Enums;

namespace SSTHub.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid BarbershopId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime StartDate { get; set; }
    public Status Status { get; set; }
    
    public Employee Employee { get; set; }
    public Customer Customer { get; set; }
    public Barbershop Barbershop { get; set; }
    public Service Service { get; set; }
}
