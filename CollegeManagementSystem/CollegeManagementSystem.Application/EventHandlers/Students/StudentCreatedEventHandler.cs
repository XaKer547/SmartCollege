using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace CollegeManagementSystem.Application.EventHandlers.Students;

public sealed class StudentCreatedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<StudentCreatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(StudentCreatedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.AddEntity(notification.Student);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IStudentCreated>(new
        {
            notification.Student.Id,
            notification.Student.Firstname,
            notification.Student.Middlename,
            notification.Student.Lastname,
            GroupId = notification.Student.Group.Id,
        }, cancellationToken);
    }
}
