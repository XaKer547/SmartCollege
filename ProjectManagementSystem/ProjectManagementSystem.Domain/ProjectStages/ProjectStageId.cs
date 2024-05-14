using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStages;

public class ProjectStageId : EntityId
{
    public ProjectStageId(Guid id) : base(id) { }
    public ProjectStageId() : base() { }
}