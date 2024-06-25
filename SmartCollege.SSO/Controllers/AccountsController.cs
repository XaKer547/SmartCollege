﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCollege.SSO.Models.Accounts.Representativies;
using SmartCollege.SSO.Models.Commands;
using SmartCollege.SSO.Models.Commands.Account;
using SmartCollege.SSO.Models.Commands.College;
using SmartCollege.SSO.Models.Commands.RepresentativeOfCompany;
using SmartCollege.SSO.Models.Queries;
using SmartCollege.SSO.Shared;
using System.Security.Claims;

namespace SmartCollege.SSO.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Logup(CreateRepresentativeOfCompanyDto create)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var command = new CreateRepresentativeOfCompanyCommand(create.MiddleName,
            create.FirstName,
            create.LastName,
            create.Phone,
            create.Company,
            new CreateRepresentativeOfCompanyAccountCommand(
                create.Account.Email,
                create.Account.Password));
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
}