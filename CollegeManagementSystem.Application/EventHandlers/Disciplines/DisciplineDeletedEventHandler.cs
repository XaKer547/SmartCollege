using CollegeManagementSystem.Application.Repositories.Disciplines;
using CollegeManagementSystem.Domain.Disciplines.Events;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineDeletedEventHandler(IDisciplineWriteOnlyRepository repository) : INotificationHandler<DisciplineDeletedEvent>
{
    public async Task Handle(DisciplineDeletedEvent notification, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(notification.DisciplineId, cancellationToken);
    }
}
