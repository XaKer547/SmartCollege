using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Infrastucture.Data;

public sealed class CollegeManagementSystemDbContext(DbContextOptions options) : DbContext(options), ICollegeManagementSystemRepository
{
    public IQueryable<Group> Groups => Set<Group>();
    public IQueryable<Specialization> Specializations => Set<Specialization>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Employee> Employees => Set<Employee>();

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Add(entity);
    }

    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Update(entity);
    }

    public void DeleteEntity<TEntity>(TEntity entity) where TEntity : class
    {
        UpdateEntity(entity);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>()
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new GroupId(x));

        modelBuilder.Entity<Discipline>()
           .Property(x => x.Id)
           .HasConversion(x => x.Value, x => new DisciplineId(x));

        modelBuilder.Entity<Employee>()
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EmployeeId(x));

        modelBuilder.Entity<Specialization>()
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new SpecializationId(x));

        modelBuilder.Entity<Student>()
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new StudentId(x));

        base.OnModelCreating(modelBuilder);
    }
}