using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Domain.Services;

public interface IProjectManagementSystemRepository
{
    IQueryable<Project> Projects { get; }
    IQueryable<ProjectStage> ProjectStages { get; }
    IQueryable<Student> Students { get; }
    IQueryable<Discipline> Disciplines { get; }
    IQueryable<Group> Groups { get; }

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class;
    public void DeleteEntity<TEntityId>(TEntityId entity) where TEntityId : class;
}