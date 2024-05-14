using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using System.IO.Abstractions;

namespace ProjectManagementSystem.Application.Commands.ProjectStages;

public sealed record UpdateProjectStageCommand : IRequest
{
    public ProjectStageId ProjectStageId { get; init; }
    public ProjectId ProjectId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime Deadline { get; init; }
    public IFile[]? PinnedFiles { get; init; }
}
