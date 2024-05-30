using ProjectManagementSystem.Application.Queries.Groups;
using ProjectManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace ProjectManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGroupsQuery, IReadOnlyCollection<GroupDTO>>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public Task<IReadOnlyCollection<GroupDTO>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<GroupDTO> groups = [.. unitOfWork.Repository .Groups.Select(g => new GroupDTO
        {
            Id = g.Id.Value,
            Name = g.Name,
        })];

        return Task.FromResult(groups);
    }
}
