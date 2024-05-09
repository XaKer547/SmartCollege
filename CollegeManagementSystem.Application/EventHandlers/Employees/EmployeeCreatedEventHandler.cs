using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeCreatedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<EmployeeCreatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    public async Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.AddEntity(notification.Employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
