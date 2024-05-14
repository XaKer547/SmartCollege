using CollegeManagementSystem.Domain.Groups.Events;
using CollegeManagementSystem.Domain.Specializations;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups;

public sealed class Group : Entity<GroupId>
{
    private Group() { }
    public string Name { get; private set; }
    public Specialization Specialization { get; private set; }

    public static Group Create(string name, Specialization specialization)
    {
        var group = new Group
        {
            Name = name,
            Specialization = specialization
        };

        var groupCreatedEvent = new GroupCreatedEvent()
        {
            Group = group
        };

        group.AddEvent(groupCreatedEvent);

        return group;
    }
    public void Delete()
    {
        var groupDeletedEvent = new GroupDeletedEvent()
        {
            GroupId = Id,
        };

        AddEvent(groupDeletedEvent);
    }
    public void Update(string name, Specialization specialization)
    {
        Specialization = specialization;

        Name = name;

        var groupUpdatedEvent = new GroupUpdatedEvent()
        {
            Group = this
        };

        AddEvent(groupUpdatedEvent);
    }
}
