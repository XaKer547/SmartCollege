using CollegeManagementSystem.Application.Queries.Groups;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGroupsQuery, IReadOnlyCollection<GroupDTO>>
{
    public Task<IReadOnlyCollection<GroupDTO>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<GroupDTO> groups = [.. unitOfWork.Repository.Groups.Select(g => new GroupDTO
        {
            SpecializationId = g.Specialization.Id.Value,
            GroupId = g.Specialization.Id.Value,
            Name = g.Specialization.Name,
        })];

        return Task.FromResult(groups);
    }
}
