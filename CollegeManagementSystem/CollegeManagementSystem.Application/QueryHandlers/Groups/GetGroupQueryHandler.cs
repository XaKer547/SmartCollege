using CollegeManagementSystem.Application.Queries.Groups;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GroupDTO>
{
    public Task<GroupDTO> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
