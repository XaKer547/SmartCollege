using CollegeManagementSystem.Domain.Groups.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace CollegeManagementSystem.Application.EventHandlers.Groups;

public sealed class GroupUpdatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<GroupUpdatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(GroupUpdatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.UpdateEntity(notification.Group);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IGroupUpdated>(new
        {
            notification.Group.Id,
            notification.Group.Name,
        }, cancellationToken);
    }
}
