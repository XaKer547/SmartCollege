using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public sealed class UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateProjectCommand> validator) : IRequestHandler<UpdateProjectCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateProjectCommand> validator = validator;

    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = unitOfWork.Repository.Projects.Single(p => p.Id == request.ProjectId);

        var discipline = unitOfWork.Repository.Disciplines.SingleOrDefault(d => d.Id == request.DisciplineId);

        var group = unitOfWork.Repository.Groups.SingleOrDefault(g => g.Id == request.GroupId);

        project.Update(request.Name ?? project.Name, request.SubjectArea ?? project.SubjectArea, request.ProjectType ?? project.Type, discipline ?? project.Discipline, group ?? project.Group);

        unitOfWork.Repository.UpdateEntity(project);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
