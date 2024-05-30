using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class ProjectStageExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<ProjectStageId, ProjectStage>(context)
{
}