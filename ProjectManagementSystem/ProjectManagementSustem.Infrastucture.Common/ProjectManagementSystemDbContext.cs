using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Infrastucture.Common;

public class ProjectManagementSystemDbContext : DbContext, IProjectManagementSystemRepository
{
    public IQueryable<Project> Projects => Set<Project>();
    public IQueryable<ProjectStage> ProjectStages => Set<ProjectStage>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Group> Groups => Set<Group>();

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Add(entity);
    }
    public void DeleteEntity<TEntityId>(TEntityId entity) where TEntityId : class
    {
        Update(entity);
    }
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Update(entity);
    }
}
