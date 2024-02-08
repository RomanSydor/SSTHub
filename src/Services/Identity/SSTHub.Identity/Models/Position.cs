namespace SSTHub.Identity.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeUser> EmployeeUsers { get; set; }
    }
}
