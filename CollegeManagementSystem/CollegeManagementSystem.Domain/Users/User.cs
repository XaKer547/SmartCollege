using CollegeManagementSystem.Domain.Users.Events;
using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Users;

public abstract class User<TEntityId> : User
    where TEntityId : EntityId
{
    public TEntityId Id { get; protected set; }
}
public abstract class User : Entity
{
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    public bool Blocked { get; protected set; } = false;
    public Roles[] Roles { get; protected set; }

    private string[] RoleNames => [.. Roles.Select(r => r.ToString())];

    protected void CreateAccount(string password, Roles[] roles)
    {
        Roles = roles;

        var userCreatedEvent = new UserCreatedEvent(Email, password, RoleNames);

        AddEvent(userCreatedEvent);
    }

    public void UpdateAccount(string password, Roles[] roles, bool blocked)
    {
        Roles = roles;
        Blocked = blocked;

        var userUpdatedEvent = new UserUpdatedEvent(Email, password, RoleNames, Blocked);

        AddEvent(userUpdatedEvent);
    }

    protected void DeleteAccount()
    {
        Deleted = true;

        var userDeletedEvent = new UserDeletedEvent(Email);

        AddEvent(userDeletedEvent);
    }
}