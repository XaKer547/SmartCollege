using CollegeManagementSystem.Domain.Disciplines.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineCreatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<DisciplineCreatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(DisciplineCreatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.AddEntity(notification.Discipline);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IDisciplineCreated>(new
        {
            notification.Discipline.Id,
            notification.Discipline.Name,
        }, cancellationToken);
    }
}