using SharedKernel;

namespace ProjectManagementSystem.Domain.Projects;

public sealed class ProjectId : EntityId
{
    public ProjectId(Guid id) : base(id) { }
    public ProjectId() : base() { }
}
