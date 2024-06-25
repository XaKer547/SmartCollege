using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands.Account
{
    public abstract record CreateAccountCommand(
        string Email,
        string Password,
        bool NeedSetNewPassword,
        params Roles[] Roles) : IRequest<HandleResult<CreateAccountResult>>;

    public record CreateAccountByAdminCommand(
        string Email,
        string Password,
        params Roles[] Roles) : CreateAccountCommand(Email, Password, true, Roles);

    public record CreateRepresentativeOfCompanyAccountCommand(
        string Email,
        string Password) : CreateAccountCommand(Email, Password, false, Shared.Roles.RepresentativeOfTheCompany);
}
