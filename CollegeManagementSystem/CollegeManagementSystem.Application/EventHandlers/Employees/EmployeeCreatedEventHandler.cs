using CollegeManagementSystem.Domain.Employees.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeCreatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<EmployeeCreatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IUserCreated>(new
        {
            notification.Employee.Email,
            notification.Employee.Roles,
            //Password =
        }, cancellationToken);
    }
}
