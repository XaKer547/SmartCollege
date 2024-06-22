using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Accounts
{
    public record UpdateAccountByAdminDto(
        string? Password,
        bool? IsBlocked,
        IReadOnlyCollection<Roles>? Roles);
}
