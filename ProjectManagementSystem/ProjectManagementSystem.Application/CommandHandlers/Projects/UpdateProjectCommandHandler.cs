using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public sealed class UpdateProjectCommandHandler(IProjectManagementSystemRepository repository, IValidator<UpdateProjectCommand> validator) : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<UpdateProjectCommand> validator = validator;

    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = repository.Projects.Single(p => p.Id == request.ProjectId);

        var projectType = repository.ProjectTypes.Single(p => p.Id == request.ProjectTypeId);

        var discipline = repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        var group = repository.Groups.Single(g => g.Id == request.GroupId);

        project.Update(request.Name, request.SubjectArea, projectType, discipline, group);
    }
}
