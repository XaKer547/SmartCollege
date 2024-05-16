using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Specializations;

public sealed class SpecializationDeletedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<SpecializationDeletedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(SpecializationDeletedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IDisciplineDeleted>(new
        {

        }, cancellationToken);
    }
}
