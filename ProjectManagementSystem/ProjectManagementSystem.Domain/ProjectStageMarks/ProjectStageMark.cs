using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageMarks;

public sealed class ProjectStageMark : Entity<ProjectStageMarkId>
{
    public int Value { get; private set; }
}
