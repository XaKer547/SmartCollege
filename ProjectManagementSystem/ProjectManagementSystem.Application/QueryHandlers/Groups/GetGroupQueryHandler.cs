using ProjectManagementSystem.Application.Queries.Groups;
using ProjectManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace ProjectManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupQueryHandler(IUnitOfWork unitOfWork, IValidator<GetGroupQuery> validator) : IRequestHandler<GetGroupQuery, GroupDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetGroupQuery> validator = validator;

    public async Task<GroupDTO> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var group = unitOfWork.Repository.Groups.Where(g => g.Id == request.GroupId)
            .Select(g => new GroupDTO
            {
                Id = g.Id.Value,
                Name = g.Name,
            }).Single();

        return group;
    }
}
