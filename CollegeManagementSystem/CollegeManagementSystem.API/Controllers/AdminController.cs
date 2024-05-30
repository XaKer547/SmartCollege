using CollegeManagementSystem.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AdminController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPatch("BlockAccount")]
    public async Task<IActionResult> Update(UpdateUserCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }
}