using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations.Events;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Specializations;

public sealed class SpecializationCreatedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<SpecializationCreatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task Handle(SpecializationCreatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.AddEntity(notification.Specialization);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
