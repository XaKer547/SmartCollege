using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands.Account
{
    public record CreateAccountCommand(
        string Email,
        string Password,
        bool NeedSetNewPassword = false,
        params Roles[] Roles) : IRequest<HandleResult<CreateAccountResult>>;

    public record CreateRepresentativeOfCompanyAccountCommand(
        string Email,
        string Password) : CreateAccountCommand(Email, Password, false, Shared.Roles.RepresentativeOfTheCompany);
}
