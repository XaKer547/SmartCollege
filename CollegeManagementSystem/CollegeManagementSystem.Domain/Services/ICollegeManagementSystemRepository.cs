using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Services;

public interface ICollegeManagementSystemRepository
{
    public IQueryable<Group> Groups { get; }
    public IQueryable<Specialization> Specializations { get; }
    public IQueryable<Student> Students { get; }
    public IQueryable<Discipline> Disciplines { get; }
    public IQueryable<Employee> Employees { get; }

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class;
    public void DeleteEntity<TEntityId>(TEntityId entity) where TEntityId : class;
}
