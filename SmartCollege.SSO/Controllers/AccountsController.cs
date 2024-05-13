﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;

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
    public async Task<IActionResult> LogUp(LogupDto logup)
    {
        var result = await _mediator.Send(new CreateAccountCommand(logup.Email, logup.Password, logup.Role));

        return StatusCode(result.StatusCode, 
            new
            {
                result.Description
            });
    }
}