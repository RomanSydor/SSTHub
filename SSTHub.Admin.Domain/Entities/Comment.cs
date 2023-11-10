namespace SSTHub.Admin.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Content { get; set; }
    public Guid BarbershopId { get; set; }
    public Guid EmployeeId { get; set; }

    public Barbershop Barbershop { get; set; }
    public Employee Employee { get; set; }
}
