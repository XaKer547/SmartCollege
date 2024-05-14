using ProjectManagementSystem.Domain.Projects;

namespace ProjectManagementSystem.Application.Commands.Projects;

public sealed record DeleteProjectCommand
{
    public ProjectId ProjectId { get; init; }
}
