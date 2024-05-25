using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Users;

public abstract class User<TEntityId> : User
    where TEntityId : UserId
{
    public TEntityId Id { get; protected set; }
}

public abstract class User : Entity
{
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }
    public bool Blocked { get; protected set; } = false;
    protected void DeleteAccount()
    {
        Deleted = true;

        //var userDeletedEvent = new UserDeletedEvent(Email);

        //AddEvent(userDeletedEvent);
    }
}

public class UserRole : Entity
{
    public int Id { get; private set; }
    public UserId User { get; protected set; }
    public Roles[] Roles { get; private set; }

    public static UserRole Create(UserId userId, Roles[] roles)
    {
        var role = new UserRole()
        {
            User = userId,
            Roles = roles
        };

        return role;
    }
}