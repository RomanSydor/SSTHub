using SSTHub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SSTHub.Domain.ViewModels.Employee
{
    public class EmployeeDetailsViewModel
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public Roles Role { get; set; }
    }
}
