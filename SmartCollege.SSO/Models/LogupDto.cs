using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models
{
    public class LogupDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public Roles Role => Roles.RepresentativeOfTheCompany;
    }
}
