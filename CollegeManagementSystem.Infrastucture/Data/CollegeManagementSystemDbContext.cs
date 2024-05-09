using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Posts;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace CollegeManagementSystem.Infrastucture.Data;

public sealed class CollegeManagementSystemDbContext(DbContextOptions options) : DbContext(options), ICollegeManagementSystemRepository
{
    public IQueryable<Group> Groups => Set<Group>();
    public IQueryable<Specialization> Specializations => Set<Specialization>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Employee> Employees => Set<Employee>();
    public IQueryable<Post> Posts => Set<Post>();

    public void AddEntity<TEntity>(TEntity entity) where TEntity : Entity
    {
        Add(entity);
    }

    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : Entity
    {
        Update(entity);
    }

    public void DeleteEntity<TEntity>(TEntity entity) where TEntity : Entity
    {
        UpdateEntity(entity);
    }
}