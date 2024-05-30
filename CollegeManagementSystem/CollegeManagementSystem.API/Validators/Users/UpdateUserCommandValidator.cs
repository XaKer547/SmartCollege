using CollegeManagementSystem.Application.Commands.Users;
using CollegeManagementSystem.Domain.Students;
using CollegeManagementSystem.Domain.Users;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.UserId)
            .Must(x =>
            {
                var user = context.Users.FirstOrDefault();

                return user != null;
            });
    }
}