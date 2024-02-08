using Microsoft.AspNetCore.Identity;

namespace SSTHub.Identity.Models
{
    public class EmployeeUser : IdentityUser<int>
    {
        public int PositionId { get; set; }

        public Position Position { get; set; }
    }
}
