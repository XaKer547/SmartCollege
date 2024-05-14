using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Employees;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.MiddleName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty();

        RuleForEach(x => x.Posts)
            .Exists(context);
    }
}
