using Microsoft.AspNetCore.Identity;

namespace SSTHub.Identity.Models.Entities
{
    public class EmployeeUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PositionId { get; set; }

        public Position Position { get; set; }
    }
}
