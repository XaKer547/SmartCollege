using MediatR;
using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Commands.Account
{
    public record UpdateAccountCommand(
        string Email,
        string? Password,
        IReadOnlyCollection<Roles>? Roles,
        bool? IsBlocked,
        bool NeedSetPasswordByUser = true) : IRequest<HandleResult>;

    public record UpdateAccountByAdminCommand(
        string Email,
        string? Password,
        bool? IsBlocked,
        IReadOnlyCollection<Roles>? Roles) : UpdateAccountCommand(Email, Password, Roles, IsBlocked, true);

    public record UpdateRepresentativeAccountCommand(
        string Email,
        string? Password) : UpdateAccountCommand(Email, Password, null, false, false);
}
