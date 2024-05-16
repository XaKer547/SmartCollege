using CollegeManagementSystem.Domain.Users.Events;
using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Users;

public abstract class User<TEntityId> : Entity<TEntityId>
    where TEntityId : EntityId
{
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }

    public virtual void Update(string email, string password, Roles[] roles)
    {
        Email = email;

        var posts = roles.Select(p => p.ToString())
            .ToArray();

        var userUpdatedEvent = new UserUpdatedEvent(Email, password, posts);

        AddEvent(userUpdatedEvent);
    }
}