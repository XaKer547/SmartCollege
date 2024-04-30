using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Application.Repositories.Specializations;
using CollegeManagementSystem.Domain.Groups;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class CreateGroupCommandHandler(ISpecializationReadOnlyRepository repository) : IRequestHandler<CreateGroupCommand, GroupId>
{
    public async Task<GroupId> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var specialization = await repository.GetSpecializationAsync(request.SpecializationId);

        var group = Group.Create(request.Name, specialization);

        return group.Id;
    }
}
