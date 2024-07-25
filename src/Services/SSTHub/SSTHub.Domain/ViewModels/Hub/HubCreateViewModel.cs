using System.ComponentModel.DataAnnotations;

namespace SSTHub.Domain.ViewModels.Hub
{
    public class HubCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int OrganizationId { get; set; }
    }
}
