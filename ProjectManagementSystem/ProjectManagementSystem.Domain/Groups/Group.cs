using ProjectManagementSystem.Domain.Specializations;
using SharedKernel;

namespace ProjectManagementSystem.Domain.Groups;

public sealed class Group : Entity<GroupId>
{
    private Group() { }
    public string Name { get; private set; }
    public Specialization Specialization { get; private set; }
}
