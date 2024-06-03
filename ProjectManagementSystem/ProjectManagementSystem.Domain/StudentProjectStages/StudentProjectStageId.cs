using SharedKernel;

namespace ProjectManagementSystem.Domain.StudentProjectStages;

public class StudentProjectStageId : EntityId
{
    public StudentProjectStageId() : base() { }
    public StudentProjectStageId(Guid id) : base(id) { }
}
