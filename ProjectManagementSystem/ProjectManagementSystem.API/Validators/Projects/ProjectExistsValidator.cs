using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.Projects;

public class ProjectExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<ProjectId, Project>(context)
{
}