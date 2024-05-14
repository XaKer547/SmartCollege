using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events
{
    public sealed class StudentCreatedEvent : IDomainEvent
    {
        public required Student Student { get; set; }
    }
}
