using CollegeManagementSystem.Application.Commands.Disciplines;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class DeleteDisciplineCommandValidator : AbstractValidator<DeleteDisciplineCommand>
{
    public DeleteDisciplineCommandValidator()
    {
        RuleFor(x => x.DisciplineId)
            .NotNull();
    }
}
