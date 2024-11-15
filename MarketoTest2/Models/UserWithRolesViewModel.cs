namespace MarketoTest2.Models
{
    public class UserWithRolesViewModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
