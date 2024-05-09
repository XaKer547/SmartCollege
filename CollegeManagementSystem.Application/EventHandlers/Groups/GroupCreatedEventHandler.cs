using CollegeManagementSystem.Domain.Groups.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace CollegeManagementSystem.Application.EventHandlers.Groups;

public sealed class GroupCreatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<GroupCreatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(GroupCreatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.AddEntity(notification.Group);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IGroupCreated>(new
        {
            notification.Group.Id,
            notification.Group.Name,
        }, cancellationToken);
    }
}
