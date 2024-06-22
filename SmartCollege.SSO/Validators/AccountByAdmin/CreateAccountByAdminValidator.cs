using FluentValidation;
using SmartCollege.SSO.Models.Accounts;

namespace SmartCollege.SSO.Validators.AccountByAdmin
{
    public class CreateAccountByAdminValidator : AbstractValidator<CreateAccountByAdminDto>
    {
        public CreateAccountByAdminValidator()
        {
            RuleFor(x=> x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Roles).NotEmpty();
            RuleFor(x=> x.Password).NotEmpty();
        }
    }
}
