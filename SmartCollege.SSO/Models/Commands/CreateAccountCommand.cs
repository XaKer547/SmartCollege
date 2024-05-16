using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands
{
    public record CreateAccountCommand(
        string Email, 
        string Password, 
        string MiddleName,
        string FirstName, 
        string LastName,
        string Phone,
        string Company,
        params Roles[] Roles) : IRequest<HandleResult>;
}
