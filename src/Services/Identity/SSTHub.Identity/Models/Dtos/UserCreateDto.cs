using SSTHub.Identity.Models.Enums;

namespace SSTHub.Identity.Models.Dtos
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
