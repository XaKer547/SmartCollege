using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class CreateGroupCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<CreateGroupCommand, GroupId>
{
    public Task<GroupId> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var specialization = repository.Specializations.SingleOrDefault(s => s.Id == request.SpecializationId);

        var group = Group.Create(request.Name, specialization);

        return Task.FromResult(group.Id);
    }
}
