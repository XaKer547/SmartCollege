using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AccountController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateAccount()
    {
        await mediator.Send(null);

        return Ok();
    }

    [HttpPatch("Update/{userId:guid}")]
    public async Task<IActionResult> UpdateAccount(Guid userId)
    {
        await mediator.Send(userId);

        return Ok();
    }

    [HttpPatch("Delete/{userId:guid}")]
    public async Task<IActionResult> DeleteAccount(Guid userId)
    {
        await mediator.Send(userId);

        return Ok();
    }
}