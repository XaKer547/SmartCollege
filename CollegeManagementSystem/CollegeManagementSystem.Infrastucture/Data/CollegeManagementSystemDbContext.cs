using CollegeManagementSystem.Domain.CompanyRepresentatives;
using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students;
using CollegeManagementSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Infrastucture.Data;

public sealed class CollegeManagementSystemDbContext(DbContextOptions options) : DbContext(options), ICollegeManagementSystemRepository
{
    public IQueryable<Group> Groups => Set<Group>();
    public IQueryable<Specialization> Specializations => Set<Specialization>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Employee> Employees => Set<Employee>();
    public IQueryable<CompanyRepresentative> CompanyRepresentatives => Set<CompanyRepresentative>();
    //public IQueryable<Post> Posts => Set<Post>();
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GroupConfiguration());

        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());

        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());

        modelBuilder.ApplyConfiguration(new CompanyRepresentativeConfiguration());

        //modelBuilder.ApplyConfiguration(new PostConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public User GetUser(string email)
    {
        return Set<User>()
            .Single(u => u.Email == email);
    }

    public bool UserExists(string email)
    {
        return Set<User>()
            .Any(u => u.Email == email);
    }

    //private class PostConfiguration : IEntityTypeConfiguration<Post>
    //{
    //    public void Configure(EntityTypeBuilder<Post> builder)
    //    {
    //        var posts = Enum.GetValues<Roles>()
    //            .Select(r => new Post
    //            {
    //                Id = (int)r,
    //                Name = r.GetDisplayName()!
    //            });

    //        builder.HasData(posts);
    //    }
    //}
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

            builder.HasIndex(e => e.Email)
                .IsUnique();

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

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.Property(e => e.Blocked)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Posts)
                .HasJsonConversion()
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
    private class CompanyRepresentativeConfiguration : IEntityTypeConfiguration<CompanyRepresentative>
    {
        public void Configure(EntityTypeBuilder<CompanyRepresentative> builder)
        {
            builder.Property(e => e.Id)
                .HasConversion(e => e.Value, e => new CompanyRepresentativeId(e))
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.FirstName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.MiddleName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.LastName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.Property(e => e.Blocked)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.CompanyName)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.PhoneNumber)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(e => e.Deleted)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
public static class ValueConversionExtensions
{
    public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class
    {
        ValueConverter<T, string> converter = new(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<T>(v)
        );

        ValueComparer<T> comparer = new(
            (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
            v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
            v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v))
        );

        propertyBuilder.HasConversion(converter);
        propertyBuilder.Metadata.SetValueConverter(converter);
        propertyBuilder.Metadata.SetValueComparer(comparer);

        return propertyBuilder;
    }
}