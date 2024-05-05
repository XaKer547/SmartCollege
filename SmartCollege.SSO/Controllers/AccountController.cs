using Microsoft.AspNetCore.Mvc;

namespace SmartCollege.SSO.Controllers;

[ApiController]
[Route("/connect")]
public class AccountController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
}