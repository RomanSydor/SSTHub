namespace SSTHub.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public Guid RankId { get; set; }

    public Rank Rank { get; set; }

    public ICollection<Service> Services { get; } = new List<Service>();
    public ICollection<Like> Likes { get; } = new List<Like>();
    public ICollection<Comment> Comments { get; } = new List<Comment>();
}
