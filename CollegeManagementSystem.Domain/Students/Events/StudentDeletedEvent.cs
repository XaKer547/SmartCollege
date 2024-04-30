using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events
{
    public sealed class StudentDeletedEvent : IDomainEvent
    {
        public required StudentId StudentId { get; set; }
    }
}
