using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageMarks;

public class ProjectStageMarkId : EntityId
{
    public ProjectStageMarkId(Guid id) : base(id) { }
    public ProjectStageMarkId() : base() { }
}