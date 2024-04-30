using CollegeManagementSystem.Application.Repositories.Disciplines;
using CollegeManagementSystem.Domain.Disciplines.Events;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineUpdatedEventHandler(IDisciplineReadOnlyRepository repository) : INotificationHandler<DisciplineUpdatedEvent>
{
    public async Task Handle(DisciplineUpdatedEvent notification, CancellationToken cancellationToken)
    {
       // var discipline = await repository.GetDisciplineAsync();

    }
}
