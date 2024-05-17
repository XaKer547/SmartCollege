using CollegeManagementSystem.Application.Commands.Users;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.CommandHandlers.Users;

public sealed class UpdateUserCommandHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint, IValidator<UpdateUserCommand> validator) : IRequestHandler<UpdateUserCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;
    private readonly IValidator<UpdateUserCommand> validator = validator;

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var user = unitOfWork.Repository.GetUser(request.Email);

        user.Blocked = request.Blocked;

        /*
        string Email { get; }
        string Password { get; }
        string[] Roles { get; }
        bool Blocked { get; }
         */

        //это надо как-то в ряд событий выстроить
        unitOfWork.Repository.UpdateEntity(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish<IUserUpdated>(new
        {

        }, cancellationToken);
    }
}
