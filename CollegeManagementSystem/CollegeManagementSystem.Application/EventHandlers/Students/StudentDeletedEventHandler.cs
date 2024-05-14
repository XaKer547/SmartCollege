using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace CollegeManagementSystem.Application.EventHandlers.Students;

public sealed class StudentDeletedEventHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : INotificationHandler<StudentDeletedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(StudentDeletedEvent notification, CancellationToken cancellationToken)
    {
        unitOfWork.Repository.DeleteEntity(notification.StudentId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IStudentDeleted>(new
        {
            Id = notification.StudentId,
        }, cancellationToken);
    }
}
