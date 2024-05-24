using CollegeManagementSystem.Application.Commands.Users;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .Must(context.UserExists)
            .WithMessage("Пользователь не найден")
            .WithErrorCode("404");

        RuleForEach(x => x.Roles)
            .IsInEnum();
    }
}
