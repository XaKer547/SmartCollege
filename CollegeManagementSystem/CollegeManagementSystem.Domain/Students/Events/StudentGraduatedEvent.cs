using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events;

public sealed class StudentGraduatedEvent : IDomainEvent
{
    public StudentId Id { get; set; }
    public bool Graduated { get; set; }
}
