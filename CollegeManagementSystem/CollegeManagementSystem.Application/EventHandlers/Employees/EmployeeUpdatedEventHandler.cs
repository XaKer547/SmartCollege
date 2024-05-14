using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeUpdatedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<EmployeeUpdatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task Handle(EmployeeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.UpdateEntity(notification.Employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
