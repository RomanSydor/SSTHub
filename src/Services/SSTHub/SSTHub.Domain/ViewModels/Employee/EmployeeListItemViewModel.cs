using SSTHub.Domain.Enums;

namespace SSTHub.Domain.ViewModels.Employee
{
    public class EmployeeListItemViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
