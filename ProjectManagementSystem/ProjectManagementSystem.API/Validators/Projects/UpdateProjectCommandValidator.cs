using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.Projects;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectType)
            .IsInEnum();

        When(x => x.DisciplineId.Value != Guid.Empty, () =>
        {
            RuleFor(x => x.DisciplineId)
            .Exists(context);
        });

        When(x => x.GroupId.Value != Guid.Empty, () =>
        {
            RuleFor(x => x.GroupId)
            .Exists(context);
        });
    }
}
