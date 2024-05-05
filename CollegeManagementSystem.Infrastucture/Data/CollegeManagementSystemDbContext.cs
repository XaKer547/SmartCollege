using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Infrastucture.Data;

public sealed class CollegeManagementSystemDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Employee> Employees { get; set; }

    //what about using automapper for domain entities and DAL 
    //then domain entity -> domain POCO class
}