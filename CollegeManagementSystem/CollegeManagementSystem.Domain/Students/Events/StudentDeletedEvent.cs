using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events
{
    public sealed class StudentDeletedEvent : IDomainEvent
    {
        public StudentDeletedEvent(StudentId studentId)
        {
            StudentId = studentId;
        }

        public StudentId StudentId { get; set; }
    }
}
