using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations.Events;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Specializations;

public sealed class SpecializationDeletedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<SpecializationDeletedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task Handle(SpecializationDeletedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.DeleteEntity(notification.SpecializationId);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
