using CollegeManagementSystem.Application.Queries.Groups;
using CollegeManagementSystem.Application.Repositories.Groups;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupsQueryHandler(IGroupReadOnlyRepository repository) : IRequestHandler<GetGroupsQuery, IReadOnlyCollection<GroupDTO>>
{
    public async Task<IReadOnlyCollection<GroupDTO>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetGroupsAsync();
    }
}
