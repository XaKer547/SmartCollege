using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class UnAssignDisciplineCommandValidator : AbstractValidator<UnAssignDisciplineCommand>
{
    public UnAssignDisciplineCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.DisciplineId)
            .Exists(context);

        RuleFor(x => x.EmployeeId)
            .Exists(context);
    }
}
