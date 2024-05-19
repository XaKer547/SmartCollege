using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStagesAnswers;

public sealed record ReturnProjectStageAnswerCommand
{
    public ProjectId ProjectId { get; init; }
    public ProjectStageId ProjectStageId { get; init; }
    public string Remark { get; init; }
    public string? PinnedFile { get; init; }
}
