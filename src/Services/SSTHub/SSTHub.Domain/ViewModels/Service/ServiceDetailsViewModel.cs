namespace SSTHub.Domain.ViewModels.Service
{
    public class ServiceDetailsViewModel
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public int Price { get; set; }
    }
}
