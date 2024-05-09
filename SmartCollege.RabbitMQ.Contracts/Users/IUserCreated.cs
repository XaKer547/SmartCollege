namespace SmartCollege.RabbitMQ.Contracts.User;

public interface IUserCreated
{
    string Email { get; }
    string Password { get; }
    string[] Roles { get; }
}
