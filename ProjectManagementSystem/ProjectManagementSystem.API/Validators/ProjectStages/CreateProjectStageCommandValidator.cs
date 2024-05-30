using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class CreateProjectStageCommandValidator : AbstractValidator<CreateProjectStageCommand>
{
    public CreateProjectStageCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Deadline)
            .NotNull();

        //RuleFor(x => x.PinnedFiles)
    }
}
