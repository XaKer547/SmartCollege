using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Application.Repositories.Groups;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class DeleteGroupCommandHandler(IGroupReadOnlyRepository repository) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await repository.GetGroupAsync(request.GroupId);

        group.Delete();
    }
}
