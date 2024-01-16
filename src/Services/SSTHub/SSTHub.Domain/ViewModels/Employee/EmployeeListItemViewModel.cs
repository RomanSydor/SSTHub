using SSTHub.Domain.Enums;

namespace SSTHub.Domain.ViewModels.Employee
{
    public class EmployeeListItemViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EmployeePositions Position { get; set; }
        public int HubId { get; set; }
    }
}
