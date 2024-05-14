using SharedKernel;

namespace ProjectManagementSystem.Domain.Groups;

public sealed class GroupId : EntityId
{
    public GroupId(Guid id) : base(id) { }
    public GroupId() : base() { }
}
