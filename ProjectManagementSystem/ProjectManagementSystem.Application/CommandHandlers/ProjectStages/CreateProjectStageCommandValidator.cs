using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class CreateProjectStageCommandValidator(IProjectManagementSystemRepository repository, IValidator<CreateProjectStageCommand> validator) : IRequestHandler<CreateProjectStageCommand, ProjectStageId>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<CreateProjectStageCommand> validator = validator;

    public async Task<ProjectStageId> Handle(CreateProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = ProjectStage.Create(request.Name, request.Description, request.Deadline, request.PinnedFiles);

        return projectStage.Id;
    }
}
