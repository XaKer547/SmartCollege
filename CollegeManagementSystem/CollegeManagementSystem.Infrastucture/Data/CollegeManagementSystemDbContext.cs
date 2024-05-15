﻿using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        modelBuilder.ApplyConfiguration(new GroupConfiguration());

        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());

        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    private class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(e => e.Id)
                .HasConversion(e => e.Value, e => new GroupId(e))
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Name)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(e => e.Specialization)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
    private class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.Property(e => e.Id)
                .HasConversion(e => e.Value, e => new DisciplineId(e))
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Name)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
    private class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.Property(e => e.Id)
                .HasConversion(e => e.Value, e => new SpecializationId(e))
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Name)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
    private class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.Id)
                .HasConversion(e => e.Value, e => new StudentId(e))
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.FirstName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.MiddleName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.LastName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Email)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Graduated)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(e => e.Group)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
    private class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id)
                .HasConversion(e => e.Value, e => new EmployeeId(e))
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.FirstName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.MiddleName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.LastName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Email)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Blocked)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Roles)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}