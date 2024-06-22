using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands.College
{
    public record UpdateCollegeAccountCommand(
        string UserId,
        string Email,
        string Password,
        params Roles[] Roles) 
        : IRequest<HandleResult>;
}
