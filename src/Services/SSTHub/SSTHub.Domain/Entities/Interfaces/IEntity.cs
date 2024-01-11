namespace SSTHub.Domain.Entities.Interfaces
{
    internal interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
