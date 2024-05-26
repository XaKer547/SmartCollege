using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCollege.SSO.Models.Commands;
using SmartCollege.SSO.Models.Commands.Account;
using SmartCollege.SSO.Models.Commands.RepresentativeOfCompany;
using SmartCollege.SSO.Shared;
using System.Security.Claims;

namespace SmartCollege.SSO.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly UserHierarchy _userHierarchy;

    public AccountsController(IMediator mediator, UserHierarchy userHierarchy)
    {
        _mediator = mediator;
        _userHierarchy = userHierarchy;
    }

    [HttpPost]
    public async Task<IActionResult> Logup(CreateRepresentativeOfCompanyCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode,
            new
            {
                result.Description
            });
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode,
            new
            {
                result.Description
            });
    }

    [HttpPatch]
    [Authorize(Policy = "RepresentationRolePolicy")]
    public async Task<IActionResult> UpdateRepresentationAccount(UpdateRepresentativeOfCompanyCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var email = User.FindFirst(ClaimsIdentity.DefaultNameClaimType)!;

        var result = await _mediator.Send(new UpdateRepresentativeOfCompanyWithEmailCommand(email.Value, command));

        return StatusCode(result.StatusCode,
            new
            {
                result.Description
            });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var claims = User.FindAll(ClaimsIdentity.DefaultRoleClaimType)!;
        var roles = claims.Select(x=> Enum.Parse<Roles>(x.Value))
            .ToArray();

        if (!_userHierarchy.CheckHierarchyByRoles(roles, command.Roles))
            return Forbid();

        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode,
            new
            {
                result.Description
            });
    }

    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> UpdateAccount(UpdateAccountByAdminCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var claims = User.FindAll(ClaimsIdentity.DefaultRoleClaimType)!;
        var roles = claims.Select(x => Enum.Parse<Roles>(x.Value))
            .ToArray();

        if (command.Roles is not null
            && !_userHierarchy.CheckHierarchyByRoles(roles, command.Roles))
            return Forbid();

        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode,
            new
            {
                result.Description
            });
    }
}