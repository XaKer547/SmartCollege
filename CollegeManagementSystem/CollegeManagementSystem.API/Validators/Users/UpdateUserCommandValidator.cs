using CollegeManagementSystem.Application.Commands.Users;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(CollegeManagementSystemDbContext context)
    {
        //RuleFor(x => new EmployeeId(x.UserId))
        //    .Exists(context);

        //RuleForEach(x => x.Roles)
        //    .IsInEnum();
    }
}