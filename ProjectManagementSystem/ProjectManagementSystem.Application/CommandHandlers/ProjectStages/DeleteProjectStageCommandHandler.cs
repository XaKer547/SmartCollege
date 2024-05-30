using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class DeleteProjectStageCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteProjectStageCommand> validator) : IRequestHandler<DeleteProjectStageCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteProjectStageCommand> validator = validator;

    public async Task Handle(DeleteProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = unitOfWork.Repository.ProjectStages.Single(p => p.Id == request.ProjectStageId);

        projectStage.Delete();
    }
}
