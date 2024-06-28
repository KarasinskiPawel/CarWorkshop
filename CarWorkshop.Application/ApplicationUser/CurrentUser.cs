namespace CarWorkshop.Application.ApplicationUser
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Roles { get; set; }
        public CurrentUser(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Name = email;
            Roles = roles;
        }

        public bool IsInRole(string role) => role.Contains(role);
    }
}
