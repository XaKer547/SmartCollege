using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Application.QueryHandlers.ProjectStages;

public sealed class GetProjectStageQueryHandler(IUnitOfWork unitOfWork, IValidator<GetProjectStageQuery> validator) : IRequestHandler<GetProjectStageQuery, ProjectStageDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetProjectStageQuery> validator = validator;

    public async Task<ProjectStageDTO> Handle(GetProjectStageQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = unitOfWork.Repository.ProjectStages.Select(p => new ProjectStageDTO
        {
            Id = p.Id.Value,
            Name = p.Name,
            Description = p.Description,
            Deadline = p.Deadline,
            //PinnedFiles = p.PinnedFiles,
            //    StudentWork = p
        }).Single(p => p.Id == request.ProjectId.Value);

        return projectStage;
    }
}
