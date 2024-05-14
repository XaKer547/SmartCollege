using MediatR;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.QueryHandlers.Projects;

public sealed class GetProjectsQueryHandler(IProjectManagementSystemRepository repository) : IRequestHandler<GetProjectsQuery, IReadOnlyCollection<ProjectDTO>>
{
    private readonly IProjectManagementSystemRepository repository = repository;

    public Task<IReadOnlyCollection<ProjectDTO>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<ProjectDTO> projects = [.. repository.Projects.Select(p => new ProjectDTO
        {
            Id = p.Id.Value,
            Name = p.Name,
            SubjectArea = p.SubjectArea,
            ProjectType = p.Type.Name,
            ProjectTypeId = p.Type.Id.Value,
            DisciplineId = p.Discipline.Id.Value,
            DisciplineName = p.Discipline.Name,
        })];

        return Task.FromResult(projects);
    }
}
