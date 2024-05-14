using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageAnswers;

public class ProjectStageAnswerId:EntityId
{
    public ProjectStageAnswerId(Guid id) : base(id) { }
    public ProjectStageAnswerId() : base() { }
}