using ProjectManagementSystem.Domain.ProjectStageMarks;
using ProjectManagementSystem.Domain.Students;
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
    public Student Student { get; private set; }


    public static ProjectStage Create(Student student, string name, string description, DateTime deadline, string[] pinnedFiles)
    {
        var stage = new ProjectStage()
        {
            Name = name,
            Description = description,
            Deadline = deadline,
            PinnedFiles = pinnedFiles,
            Student = student,
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
