using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands
{
    public record UpdateAccountCommand(
        string Email,
        string Password,
        params Roles[] Roles) : IRequest<HandleResult>;
}
