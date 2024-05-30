using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public sealed class CreateProjectCommandHandler(IProjectManagementSystemRepository repository, IValidator<CreateProjectCommand> validator) : IRequestHandler<CreateProjectCommand, ProjectId>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<CreateProjectCommand> validator = validator;

    public async Task<ProjectId> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectType = repository.ProjectTypes.Single(p => p.Id == request.ProjectTypeId);

        var discipline = repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        var group = repository.Groups.Single(g => g.Id == request.GroupId);

        var project = Project.Create(request.Name, request.SubjectArea, projectType, discipline, group);

        return project.Id;
    }
}