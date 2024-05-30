using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectTypes;

public class ProjectTypeId : EntityId
{
    public ProjectTypeId(Guid id) : base(id) { }
    public ProjectTypeId() : base() { }
}