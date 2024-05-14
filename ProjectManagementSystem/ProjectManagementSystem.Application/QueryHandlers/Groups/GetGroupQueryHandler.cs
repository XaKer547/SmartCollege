using ProjectManagementSystem.Application.Queries.Groups;
using ProjectManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace ProjectManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupQueryHandler(IProjectManagementSystemRepository repository, IValidator<GetGroupQuery> validator) : IRequestHandler<GetGroupQuery, GroupDTO>
{
    private readonly IProjectManagementSystemRepository repository = repository;
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
