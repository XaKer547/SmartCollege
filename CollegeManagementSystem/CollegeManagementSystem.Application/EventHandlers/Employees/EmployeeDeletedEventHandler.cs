using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeDeletedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<EmployeeDeletedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(EmployeeDeletedEvent notification, CancellationToken cancellationToken)
    {
        var employee = unitOfWork.Repository.Employees.SingleOrDefault(e => e.Id == notification.EmployeeId);

        unitOfWork.Repository.DeleteEntity(employee.Id);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IUserDeleted>(new
        {
            employee.Id,
        }, cancellationToken);
    }
}
