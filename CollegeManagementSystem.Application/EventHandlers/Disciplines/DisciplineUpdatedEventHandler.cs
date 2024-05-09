using CollegeManagementSystem.Domain.Disciplines.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineUpdatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<DisciplineUpdatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(DisciplineUpdatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.UpdateEntity(notification.Discipline);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IDisciplineUpdated>(new
        {
            notification.Discipline.Id,
            notification.Discipline.Name,
        }, cancellationToken);
    }
}
