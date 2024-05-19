using SharedKernel;

namespace ProjectManagementSystem.Domain.Groups;

public sealed class Group : Entity<GroupId>
{
    private Group() { }
    public string Name { get; private set; }
}
