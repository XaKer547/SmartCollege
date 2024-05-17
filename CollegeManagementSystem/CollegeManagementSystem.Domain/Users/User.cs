using CollegeManagementSystem.Domain.Users.Events;
using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Users;

public abstract class User<TEntityId> : User
    where TEntityId : EntityId
{
    public TEntityId Id { get; private set; }
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    public bool Blocked { get; protected set; }

    protected void CreateAccount(string password, Roles[] roles)
    {
        var userCreatedEvent = new UserCreatedEvent(Email, password);

        AddEvent(userCreatedEvent);
    }

    protected void UpdateAccount(string password, Roles[] roles)
    {
        var posts = roles.Select(p => p.ToString())
            .ToArray();

        var userUpdatedEvent = new UserUpdatedEvent(Email, password, posts);

        AddEvent(userUpdatedEvent);
    }

    protected void DeleteAccount()
    {
        Deleted = true;

        var userDeletedEvent = new UserDeletedEvent(Email);

        AddEvent(userDeletedEvent);
    }
}
public abstract class User : Entity
{
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    public bool Blocked { get; protected set; }


    protected void CreateAccount(string password, Roles[] roles)
    {
        var userCreatedEvent = new UserCreatedEvent(Email, password);

        AddEvent(userCreatedEvent);
    }

    protected void UpdateAccount(string password, Roles[] roles)
    {
        var posts = roles.Select(p => p.ToString())
            .ToArray();

        var userUpdatedEvent = new UserUpdatedEvent(Email, password, posts);

        AddEvent(userUpdatedEvent);
    }

    protected void DeleteAccount()
    {
        Deleted = true;

        var userDeletedEvent = new UserDeletedEvent(Email);

        AddEvent(userDeletedEvent);
    }
}