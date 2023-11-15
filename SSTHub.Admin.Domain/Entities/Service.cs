namespace SSTHub.Domain.Entities;

public class Service
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Price { get; set; }

    public Employee Employee { get; set; }
    public Guid EmployeeId { get; set; }

    public ICollection<Event> Events { get; set; }

}
