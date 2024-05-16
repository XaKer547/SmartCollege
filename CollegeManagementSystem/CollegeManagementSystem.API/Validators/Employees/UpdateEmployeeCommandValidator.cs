using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Employees;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.EmployeeId)
           .Exists(context);

        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.Posts)
            .NotEmpty()
            .IsInEnum();
    }
}
