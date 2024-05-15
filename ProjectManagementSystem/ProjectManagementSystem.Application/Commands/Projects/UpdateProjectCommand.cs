using MediatR;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectTypes;

namespace ProjectManagementSystem.Application.Commands.Projects;

public sealed record UpdateProjectCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
    public string Name { get; init; }
    public string SubjectArea { get; init; }
    public ProjectTypeId ProjectTypeId { get; init; }
    public DisciplineId DisciplineId { get; init; }
    public GroupId GroupId { get; init; }
}