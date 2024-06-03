using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class CreateProjectStageCommandValidator(IUnitOfWork unitOfWork, IValidator<CreateProjectStageCommand> validator) : IRequestHandler<CreateProjectStageCommand, ProjectStageId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CreateProjectStageCommand> validator = validator;

    public async Task<ProjectStageId> Handle(CreateProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = unitOfWork.Repository.Projects.Single(p => p.Id == request.ProjectId);

        //var students = unitOfWork.Repository.Students.Where(s => s.);

        //var projectStage = ProjectStage.Create(null, request.Name, request.Description, request.Deadline, request.PinnedFiles);

        //project.Stages.Add(projectStage);

        //unitOfWork.Repository.UpdateEntity(project);

        //await unitOfWork.SaveChangesAsync(cancellationToken);

        //return projectStage.Id;

        return null;
    }
}
