using CollegeManagementSystem.Application.Repositories.Disciplines;
using CollegeManagementSystem.Domain.Disciplines.Events;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineCreatedEventHandler(IDisciplineWriteOnlyRepository repository) : INotificationHandler<DisciplineCreatedEvent>
{
    public async Task Handle(DisciplineCreatedEvent notification, CancellationToken cancellationToken)
    {
        await repository.AddAsync(notification.Discipline, cancellationToken);
    }
}
