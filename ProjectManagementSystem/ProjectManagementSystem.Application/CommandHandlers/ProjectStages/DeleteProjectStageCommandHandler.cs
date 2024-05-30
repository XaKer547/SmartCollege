using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class DeleteProjectStageCommandHandler(IProjectManagementSystemRepository repository, IValidator<DeleteProjectStageCommand> validator) : IRequestHandler<DeleteProjectStageCommand>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<DeleteProjectStageCommand> validator = validator;

    public async Task Handle(DeleteProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = repository.ProjectStages.Single(p => p.Id == request.ProjectStageId);

        projectStage.Delete();
    }
}
