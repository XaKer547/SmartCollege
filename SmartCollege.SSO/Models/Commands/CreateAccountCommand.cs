using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands
{
    public record CreateAccountCommand(string Email, string Password, params Roles[] Roles) : IRequest<HandleResult>;
}
