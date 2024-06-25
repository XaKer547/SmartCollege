using SmartCollege.SSO.Shared;

namespace SmartCollege.SSO.Models.Accounts
{
    public record CreateAccountByAdminDto(Guid Id,
        string Email,
        string Password,
        params Roles[] Roles);
}
