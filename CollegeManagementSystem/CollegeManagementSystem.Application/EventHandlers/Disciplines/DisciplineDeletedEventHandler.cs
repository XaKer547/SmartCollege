using CollegeManagementSystem.Domain.Disciplines.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineDeletedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<DisciplineDeletedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(DisciplineDeletedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.DeleteEntity(notification.DisciplineId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IDisciplineDeleted>(new
        {
            Id = notification.DisciplineId,
        }, cancellationToken);
    }
}
