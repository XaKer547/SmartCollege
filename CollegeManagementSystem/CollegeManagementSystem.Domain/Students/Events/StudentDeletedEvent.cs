using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events
{
    public sealed class StudentDeletedEvent : IDomainEvent
    {
        public StudentDeletedEvent(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
