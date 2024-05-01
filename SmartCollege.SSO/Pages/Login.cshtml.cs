using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCollege.SSO.Models;

namespace SmartCollege.SSO.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInput Input { get; set; }

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet(string? redirectUri = null)
        {
            Input = new LoginInput { RedirectUri = redirectUri };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user is null)
            {
                ModelState.AddModelError(nameof(Input.Email), "Пользователь не найден!");
                return Page();
            }

            var result  = await _signInManager.PasswordSignInAsync(user, Input.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(Input.Email), "А ты петух, как я полгяжу");
                return Page();
            }

            if (Input.RedirectUri is null)
                return RedirectToPage("Index");

            return Redirect(Input.RedirectUri);
        }
    }
}
