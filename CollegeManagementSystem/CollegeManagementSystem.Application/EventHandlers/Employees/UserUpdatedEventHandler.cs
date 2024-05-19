using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Helpers;
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
            Roles = notification.Employee.Posts.Select(r => r.GetDisplayName()!)
            .ToArray(),
        }, cancellationToken);
    }
}