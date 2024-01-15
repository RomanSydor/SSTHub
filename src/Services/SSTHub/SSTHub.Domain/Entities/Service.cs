using SSTHub.Domain.Entities.Interfaces;

namespace SSTHub.Domain.Entities
{
    public class Service : IEntity, IActivatable
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public int Price { get; set; }
        //public int EmployeeId { get; set; }

        //public Employee Employee { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
