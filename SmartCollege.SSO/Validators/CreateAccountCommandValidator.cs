using FluentValidation;
using SmartCollege.SSO.Models;

namespace SmartCollege.SSO.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<LogupDto>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(8);
        }
    }
}
