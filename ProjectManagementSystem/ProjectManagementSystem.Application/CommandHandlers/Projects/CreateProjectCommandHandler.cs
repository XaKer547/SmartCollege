using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public sealed class CreateProjectCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateProjectCommand> validator) : IRequestHandler<CreateProjectCommand, ProjectId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CreateProjectCommand> validator = validator;

    public async Task<ProjectId> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var discipline = unitOfWork.Repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        var group = unitOfWork.Repository.Groups.Single(g => g.Id == request.GroupId);

        var project = Project.Create(request.Name, request.SubjectArea, request.ProjectType, discipline, group);

        unitOfWork.Repository.AddEntity(project);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}