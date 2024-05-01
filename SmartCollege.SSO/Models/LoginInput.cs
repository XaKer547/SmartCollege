using System.ComponentModel.DataAnnotations;

namespace SmartCollege.SSO.Models
{
    public class LoginInput
    {
        [Display(Name = "Логин")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string? RedirectUri { get; set; }

        public bool RememberConsent { get; set; } = true;
    }
}
