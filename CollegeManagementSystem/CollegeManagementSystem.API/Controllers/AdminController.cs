using CollegeManagementSystem.Application.Commands.Users;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AdminController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPatch("Update")]
    public async Task<IActionResult> Update(UpdateUserCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }

    [HttpPatch("Block")]
    public async Task<IActionResult> DeleteAccount(BlockUserCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }
}