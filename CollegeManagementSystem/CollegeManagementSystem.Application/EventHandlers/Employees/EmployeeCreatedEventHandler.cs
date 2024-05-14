using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeCreatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<EmployeeCreatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.AddEntity(notification.Employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IUserCreated>(new
        {
            notification.Employee.Email,
            Roles = notification.Employee.Posts.Select(p => p.Id.ToString())
            .ToArray(),
            Password = ""
            //там же одноразовый и прочее
        }, cancellationToken);
    }
}
