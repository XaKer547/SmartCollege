using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Users;

public class UniqueEmailValidator : AbstractValidator<string>
{
    public UniqueEmailValidator(CollegeManagementSystemDbContext context)
    {
        //RuleFor(x => x)
        //    .Must(x => !context.UserExists(x))
        //    .WithMessage("Данная почта уже занята")
        //    .WithErrorCode("400");
    }
}