using MediatR;
using SmartCollege.SSO.Models.Commands.Account;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands.College
{
    public record CreateCollegeAccountCommand(
        string UserId,
        string Email, 
        string Password, 
        params Roles[] Roles)
        : CreateAccountCommand(Email, Password, true, Roles);
}
