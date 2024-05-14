using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Projects.Events;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.ProjectTypes;
using SharedKernel;
using System.Text.RegularExpressions;

namespace ProjectManagementSystem.Domain.Projects;

public sealed class Project : Entity<ProjectId>
{
    private Project() { }

    public string Name { get; private set; }
    public string SubjectArea { get; private set; }
    public ProjectType Type { get; private set; }
    public Discipline Discipline { get; private set; }
    public Group Group { get; private set; }

    public bool Completed { get; private set; }
    public List<ProjectStage> Stages { get; private set; }

    public static Project Create(string name, string subjectArea, ProjectType type, Discipline discipline)
    {
        var project = new Project()
        {
            Name = name,
            SubjectArea = subjectArea,
            Type = type,
            Discipline = discipline
        };

        var projectCreatedEvent = new ProjectCreatedEvent()
        {
            Project = project,
        };

        project.AddEvent(projectCreatedEvent);

        return project;
    }
    public void Update(string name, string subjectArea, ProjectType type, Discipline discipline)
    {
        Name = name;
        SubjectArea = subjectArea;
        Type = type;
        Discipline = discipline;
    }
    public void Delete()
    {
        Deleted = true;

        //var projectDeletedEvent = new ProjectDeletedEvent()
        //{
        //    ProjectId = Id
        //};

        //AddEvent(projectDeletedEvent);
    }
}