using ProjectManagementSystem.Domain.Students;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageAnswers;

public sealed class ProjectStageAnswer : Entity<ProjectStageAnswerId>
{
    public Student Student { get; private set; }
    public string[] Files { get; private set; }
    public bool Returned { get; private set; }
    public string? Remark { get; private set; }
}
