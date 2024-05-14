using MediatR;
using ProjectManagementSystem.Domain.Groups;
using SharedKernel.DTOs.Groups;

namespace ProjectManagementSystem.Application.Queries.Groups;

public sealed record GetGroupQuery : IRequest<GroupDTO>
{
    public GroupId GroupId { get; init; }
}
