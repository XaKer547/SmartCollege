using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace CollegeManagementSystem.Application.EventHandlers.Students;

public sealed class StudentUpdatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<StudentUpdatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(StudentUpdatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.UpdateEntity(notification.Student);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IStudentUpdated>(new
        {
            notification.Student.Id,
            notification.Student.Firstname,
            notification.Student.Middlename,
            notification.Student.Lastname,
            GroupId = notification.Student.Group.Id,
        }, cancellationToken);
    }
}
