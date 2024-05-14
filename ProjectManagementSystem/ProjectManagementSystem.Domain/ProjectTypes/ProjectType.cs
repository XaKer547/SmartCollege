using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectTypes;

public sealed class ProjectType : Entity<ProjectTypeId>
{
    public string Name { get; private set; }
}
