using System.ComponentModel.DataAnnotations;

namespace SSTHub.Domain.ViewModels.Employee
{
    public class EmployeeCreateViewModel
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
