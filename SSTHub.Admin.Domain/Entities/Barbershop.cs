namespace SSTHub.Admin.Domain.Entities;

public class Barbershop
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }



    public ICollection<Employee> Employees { get; } = new List<Employee>();
    public ICollection<Like> Likes { get; } = new List<Like>();
    public ICollection<Comment> Comments { get; } = new List<Comment>();
}

