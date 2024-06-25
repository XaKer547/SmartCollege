using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCollege.SSO.Models.Accounts;
using SmartCollege.SSO.Models.Commands.Account;
using SmartCollege.SSO.Models.Queries;
using SmartCollege.SSO.Shared;
using System.Security.Claims;

namespace SmartCollege.SSO.Controllers
{
    [Route("admin/api/accounts/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly UserHierarchy _userHierarchy;

        public AdminsController(IMediator mediator, UserHierarchy userHierarchy)
        {
            _mediator = mediator;
            _userHierarchy = userHierarchy;
        }

        [HttpGet("{userId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetAccount(string userId)
        {
            var result = await _mediator.Send(new GetAccountQuery(userId));

            return StatusCode(result.StatusCode,
                new
                {
                    result.Result
                });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAccount(CreateAccountByAdminDto create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

            var claims = User.FindAll(ClaimsIdentity.DefaultRoleClaimType)!;
            var roles = claims.Select(x => Enum.Parse<Roles>(x.Value))
                .ToArray();

            if (!_userHierarchy.CheckHierarchyByRoles(roles, create.Roles))
                return Forbid();

            var command = new CreateAccountByAdminCommand(create.Email, create.Password, create.Roles);

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode,
                new
                {
                    result.Description
                });
        }

        [HttpPatch("{email}")]
        [Authorize]
        public async Task<IActionResult> UpdateAccount(string email, UpdateAccountByAdminDto update)
        {
            if (string.IsNullOrWhiteSpace(email))
                ModelState.AddModelError(nameof(email), "Email не указан!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

            var claims = User.FindAll(ClaimsIdentity.DefaultRoleClaimType)!;
            var roles = claims.Select(x => Enum.Parse<Roles>(x.Value))
            .ToArray();

            if (update.Roles is not null 
                && !_userHierarchy.CheckHierarchyByRoles(roles, update.Roles))
                return Forbid();

            var command = new UpdateAccountByAdminCommand(email, update.Password, update.IsBlocked, update.Roles);

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode,
                new
                {
                    result.Description
                });
        }
    }
}
