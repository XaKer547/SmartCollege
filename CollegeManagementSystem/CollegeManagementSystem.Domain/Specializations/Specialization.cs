using CollegeManagementSystem.Domain.Specializations.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations;

public sealed class Specialization : Entity<SpecializationId>
{
    private Specialization() { }
    public string Name { get; private set; }

    public static Specialization Create(string name)
    {
        var specialization = new Specialization()
        {
            Name = name
        };

        specialization.AddEvent(new SpecializationCreatedEvent()
        {
            Specialization = specialization
        });

        return specialization;
    }
    public void Update(string name)
    {
        Name = name;

        var specializationUpdatedEvent = new SpecializationUpdatedEvent()
        {
            Specialization = this
        };

        AddEvent(specializationUpdatedEvent);
    }
    public void Delete()
    {
        var specializationDeletedEvent = new SpecializationDeletedEvent()
        {
            SpecializationId = Id
        };

        AddEvent(specializationDeletedEvent);
    }
}
