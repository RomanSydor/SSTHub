using System.ComponentModel.DataAnnotations;

namespace SSTHub.Identity.Models.Dtos
{
    public class OrganizationCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
