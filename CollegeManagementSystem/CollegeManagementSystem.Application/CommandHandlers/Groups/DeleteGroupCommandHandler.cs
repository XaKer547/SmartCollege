using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class DeleteGroupCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<DeleteGroupCommand>
{
    public Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = repository.Groups.SingleOrDefault(g => g.Id == request.GroupId);

        group.Delete();

        return Task.CompletedTask;
    }
}
