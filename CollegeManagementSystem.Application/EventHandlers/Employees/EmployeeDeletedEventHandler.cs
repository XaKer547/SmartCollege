using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeDeletedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<EmployeeDeletedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task Handle(EmployeeDeletedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.DeleteEntity(notification.EmployeeId);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
