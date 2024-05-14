using CollegeManagementSystem.Application.Queries.Groups;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupQueryHandler(ICollegeManagementSystemRepository repository, IValidator<GetGroupQuery> validator) : IRequestHandler<GetGroupQuery, GroupDTO>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<GetGroupQuery> validator = validator;

    public async Task<GroupDTO> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var group = repository.Groups.Select(g => new GroupDTO
        {
            GroupId = g.Id.Value,
            Name = g.Name,
            SpecializationId = g.Specialization.Id.Value
        }).Single(g => g.GroupId == request.GroupId.Value);

        return group;
    }
}
