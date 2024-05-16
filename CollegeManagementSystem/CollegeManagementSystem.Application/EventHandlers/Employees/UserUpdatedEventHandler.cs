using CollegeManagementSystem.Domain.Employees.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

internal class UserUpdatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<EmployeeUpdatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(EmployeeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IUserUpdated>(new
        {
            notification.Employee.Email,
            Roles = notification.Employee.Roles.Select(r => r.ToString())
            .ToArray(),
        }, cancellationToken);
    }
}