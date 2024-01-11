using SSTHub.Domain.Entities.Interfaces;

namespace SSTHub.Domain.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
