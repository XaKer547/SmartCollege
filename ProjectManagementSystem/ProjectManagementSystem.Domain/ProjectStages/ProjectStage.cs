using ProjectManagementSystem.Domain.ProjectStageMarks;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStages;

public sealed class ProjectStage : Entity<ProjectStageId>
{
    private ProjectStage() { }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Deadline { get; private set; }
    public string[]? PinnedFiles { get; private set; }
    public ProjectStageMark? Mark { get; private set; } = null;



    public static ProjectStage Create(string name, string description, DateTime deadline, string[] pinnedFiles)
    {
        var stage = new ProjectStage()
        {
            Name = name,
            Description = description,
            Deadline = deadline,
            PinnedFiles = pinnedFiles
        };

        return stage;
    }
    public void Update(string name, string description, DateTime deadline, string[] pinnedFiles)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        PinnedFiles = pinnedFiles;
    }
    public void Delete()
    {
        Deleted = true;
    }
}
