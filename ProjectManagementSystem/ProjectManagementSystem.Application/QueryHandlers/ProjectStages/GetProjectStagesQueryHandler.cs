using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Application.QueryHandlers.ProjectStages;

public sealed class GetProjectStagesQueryHandler(IProjectManagementSystemRepository repository, IValidator<GetProjectStagesQuery> validator) : IRequestHandler<GetProjectStagesQuery, IReadOnlyCollection<ProjectStageDTO>>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<GetProjectStagesQuery> validator = validator;

    public async Task<IReadOnlyCollection<ProjectStageDTO>> Handle(GetProjectStagesQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        IReadOnlyCollection<ProjectStageDTO> projectStages = [.. repository.ProjectStages.Select(p => new ProjectStageDTO
        {
            Id = p.Id.Value,
            Name = p.Name,
            Description = p.Description,
            Deadline = p.Deadline,
            PinnedFiles = p.PinnedFiles,
          //StudentWork = p
        })];

        return projectStages;
    }
}
