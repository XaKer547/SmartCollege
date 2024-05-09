namespace SmartCollege.RabbitMQ.Contracts.User;

public interface IUserUpdated
{
    string Email { get; }
    string Password { get; }
    string[] Roles { get; }
}
