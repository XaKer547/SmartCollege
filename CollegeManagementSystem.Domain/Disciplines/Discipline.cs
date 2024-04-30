﻿using CollegeManagementSystem.Domain.Disciplines.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines;

public sealed class Discipline : Entity
{
    private Discipline() { }

    public DisciplineId Id { get; private set; }
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
}
