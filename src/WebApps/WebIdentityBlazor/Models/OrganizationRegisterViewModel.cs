using System.ComponentModel.DataAnnotations;

namespace WebIdentityBlazor.Models
{
    public class OrganizationRegisterViewModel
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
        public string OrganizationName { get; set; }
    }
}
