using MediatR;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Users.Events;

public sealed class UserUpdatedEvent : IDomainEvent
{
    public UserUpdatedEvent(string email, string password, string[] strings)
    {
        Email = email;
        Password = password;
        Roles = strings;
    }

    public string Email { get; init; }
    public string Password { get; init; }
    public string[] Roles { get; init; }
}