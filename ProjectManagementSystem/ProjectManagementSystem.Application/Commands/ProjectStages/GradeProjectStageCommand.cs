using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Application.Commands.ProjectStages;

public sealed record GradeProjectStageCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
    public ProjectStageId ProjectStageId { get; init; }
    public StudentId StudentId { get; init; }
    public int Grade { get; init; }
}
