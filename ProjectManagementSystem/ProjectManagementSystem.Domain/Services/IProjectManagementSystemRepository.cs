using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectTypes;
using System.Text.RegularExpressions;

namespace ProjectManagementSystem.Domain.Services;

public interface IProjectManagementSystemRepository
{
    IQueryable<Project> Projects { get; }
    IQueryable<ProjectType> ProjectTypes { get; }

    public IQueryable<Group> Groups { get; }
    public IQueryable<Discipline> Disciplines { get; }

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class;
    public void DeleteEntity<TEntityId>(TEntityId entity) where TEntityId : class;
}
