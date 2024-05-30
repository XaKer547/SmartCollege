using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public sealed class DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteProjectCommand> validator) : IRequestHandler<DeleteProjectCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteProjectCommand> validator = validator;

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = unitOfWork.Repository.Projects.Single(p => p.Id == request.ProjectId);

        project.Delete();

        unitOfWork.Repository.DeleteEntity(project);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
