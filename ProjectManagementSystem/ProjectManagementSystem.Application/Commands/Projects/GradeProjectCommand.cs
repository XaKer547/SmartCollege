using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Application.Commands.Projects;

public sealed record GradeProjectCommand
{
    public ProjectId ProjectId { get; init; }
    public StudentId StudentId { get; init; }
    public int Grade { get; init; }
}
