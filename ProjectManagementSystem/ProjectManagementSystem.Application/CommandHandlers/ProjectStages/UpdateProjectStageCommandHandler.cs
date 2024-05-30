using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class UpdateProjectStageCommandHandler(IProjectManagementSystemRepository repository, IValidator<UpdateProjectStageCommand> validator) : IRequestHandler<UpdateProjectStageCommand>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<UpdateProjectStageCommand> validator = validator;

    public async Task Handle(UpdateProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = repository.ProjectStages.Single(p => p.Id == request.ProjectStageId);

        projectStage.Update(request.Name, request.Description, request.Deadline, request.PinnedFiles);
    }
}
