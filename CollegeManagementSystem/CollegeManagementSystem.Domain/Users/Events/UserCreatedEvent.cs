using SharedKernel;

namespace CollegeManagementSystem.Domain.Users.Events;

public sealed class UserCreatedEvent : IDomainEvent
{
    public string Email { get; init; }

    public UserCreatedEvent(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Password { get; init; }
    public string[] Roles { get; init; }
}
