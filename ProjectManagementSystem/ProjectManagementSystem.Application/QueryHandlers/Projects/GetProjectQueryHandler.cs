using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Domain.Helpers;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.QueryHandlers.Projects;

public sealed class GetProjectQueryHandler(IUnitOfWork unitOfWork, IValidator<GetProjectQuery> validator) : IRequestHandler<GetProjectQuery, ProjectDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetProjectQuery> validator = validator;

    public async Task<ProjectDTO> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = unitOfWork.Repository.Projects.Where(p => p.Id == request.ProjectId)
            .Select(p => new ProjectDTO
            {
                Id = p.Id.Value,
                Name = p.Name,
                SubjectArea = p.SubjectArea,
                ProjectType = p.Type.GetDisplayName()!,
                ProjectTypeId = (int)p.Type,
                DisciplineId = p.Discipline.Id.Value,
                DisciplineName = p.Discipline.Name,
            }).Single();

        return project;
    }
}
