using FluentValidation;
using SmartCollege.SSO.Models.Accounts;

namespace SmartCollege.SSO.Validators.AccountByAdmin
{
    public class UpdateAccountByAdminValidator : AbstractValidator<UpdateAccountByAdminDto>
    {
        public UpdateAccountByAdminValidator()
        {
        }
    }
}
