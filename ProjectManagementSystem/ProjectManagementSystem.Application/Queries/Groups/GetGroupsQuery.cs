using MediatR;
using SharedKernel.DTOs.Groups;

namespace ProjectManagementSystem.Application.Queries.Groups;

public sealed record GetGroupsQuery : IRequest<IReadOnlyCollection<GroupDTO>>
{
    
}
