using System.ComponentModel.DataAnnotations;

namespace SSTHub.Identity.Models.Dtos
{
    public class HubCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
