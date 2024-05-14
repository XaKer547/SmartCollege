using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Employees;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Posts;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.ProjectTypes;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Domain.Services;

public interface IProjectManagementSystemRepository
{
    IQueryable<Project> Projects { get; }
    IQueryable<ProjectType> ProjectTypes { get; }
    IQueryable<ProjectStage> ProjectStages { get; }
    IQueryable<Student> Students { get; }
    IQueryable<Employee> Employees { get; }
    IQueryable<Post> Posts { get; }
    IQueryable<Discipline> Disciplines { get; }
    IQueryable<Group> Groups { get; }

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class;
    public void DeleteEntity<TEntityId>(TEntityId entity) where TEntityId : class;
}
