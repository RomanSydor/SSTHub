namespace SSTHub.Domain.Entities;

public class Rank
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Premium { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
