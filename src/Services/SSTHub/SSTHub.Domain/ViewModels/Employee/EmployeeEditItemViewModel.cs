using SSTHub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SSTHub.Domain.ViewModels.Employee
{
    public class EmployeeEditItemViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
