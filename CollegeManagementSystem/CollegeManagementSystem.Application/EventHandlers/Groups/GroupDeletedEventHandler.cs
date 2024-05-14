using CollegeManagementSystem.Domain.Groups.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace CollegeManagementSystem.Application.EventHandlers.Groups;

public sealed class GroupDeletedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<GroupDeletedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(GroupDeletedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.DeleteEntity(notification.GroupId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IGroupDeleted>(new
        {
            Id = notification.GroupId,
        }, cancellationToken);
    }
}
