using SSTHub.Identity.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SSTHub.Identity.Models.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public int HubId { get; set; }
    }
}
