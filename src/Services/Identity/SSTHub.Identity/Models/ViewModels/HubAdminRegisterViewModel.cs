using System.ComponentModel.DataAnnotations;

namespace SSTHub.Identity.Models.ViewModels
{
    public class HubAdminRegisterViewModel
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
        public string Password { get; set; }
        [Required]
        public string HubName { get; set; }
    }
}
