using CollegeManagementSystem.Domain.Disciplines.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines;

public sealed class Discipline : Entity<DisciplineId>
{
    private Discipline() { }
    public string Name { get; private set; }

    public static Discipline Create(string name)
    {
        var discipline = new Discipline()
        {
            Name = name,
        };

        var disciplineCreatedEvent = new DisciplineCreatedEvent()
        {
            Discipline = discipline,
        };

        discipline.AddEvent(disciplineCreatedEvent);

        return discipline;
    }
    public void Delete()
    {
        var disciplineDeletedEvent = new DisciplineDeletedEvent()
        {
            DisciplineId = Id,
        };

        AddEvent(disciplineDeletedEvent);
    }

    public void Update(string name)
    {
        Name = name;

        var disciplineUpdatedEvent = new DisciplineUpdatedEvent()
        {
            Discipline = this
        };

        AddEvent(disciplineUpdatedEvent);
    }
}
