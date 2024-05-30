using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public sealed class DeleteProjectCommandHandler(IProjectManagementSystemRepository repository, IValidator<DeleteProjectCommand> validator) : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<DeleteProjectCommand> validator = validator;

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = repository.Projects.Single(p => p.Id == request.ProjectId);

        project.Delete();
    }
}
