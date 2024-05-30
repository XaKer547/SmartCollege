using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.QueryHandlers.Projects;

public sealed class GetProjectQueryHandler(IProjectManagementSystemRepository repository, IValidator<GetProjectQuery> validator) : IRequestHandler<GetProjectQuery, ProjectDTO>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<GetProjectQuery> validator = validator;

    public async Task<ProjectDTO> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = repository.Projects.Select(p => new ProjectDTO
        {
            Id = p.Id.Value,
            Name = p.Name,
            SubjectArea = p.SubjectArea,
            ProjectType = p.Type.Name,
            ProjectTypeId = p.Type.Id.Value,
            DisciplineId = p.Discipline.Id.Value,
            DisciplineName = p.Discipline.Name,
        }).Single(p => p.Id == request.ProjectId.Value);

        return project;
    }
}
