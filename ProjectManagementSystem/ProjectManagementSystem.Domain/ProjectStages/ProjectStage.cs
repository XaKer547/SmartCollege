using ProjectManagementSystem.Domain.Projects;
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
    public PinnedFile[]? PinnedFiles { get; private set; }
    public ProjectStageMark? Mark { get; private set; } = null;
    public Student Student { get; private set; }
    public Project Project { get; private set; }

    public static ProjectStage Create(Student student, string name, string description, DateTime deadline, PinnedFile[]? pinnedFiles)
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
    public void Update(string name, string description, DateTime deadline, PinnedFile[] pinnedFiles)
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

public class PinnedFile
{
    private PinnedFile()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ProjectName { get; private set; }
    public string ProjectStageName { get; private set; }

    public static PinnedFile Create(string projectName, string projectStageName, string name)
    {
        var file = new PinnedFile()
        {
            Name = name,
            ProjectName = projectName,
            ProjectStageName = projectStageName,
        };

        return file;
    }

    public string GetPath()
    {
        return Path.Combine(Id.ToString(), ProjectName, ProjectStageName);
    }
}