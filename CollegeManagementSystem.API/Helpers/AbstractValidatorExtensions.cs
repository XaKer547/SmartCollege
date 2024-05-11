using CollegeManagementSystem.API.Validators.Disciplines;
using CollegeManagementSystem.API.Validators.Employees;
using CollegeManagementSystem.API.Validators.Grops;
using CollegeManagementSystem.API.Validators.Posts;
using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Posts;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Helpers;

public static class AbstractValidatorExtensions
{
    public static IRuleBuilderOptions<T, PostId> Exists<T>(this IRuleBuilder<T, PostId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new PostExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, GroupId> Exists<T>(this IRuleBuilder<T, GroupId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new GroupExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, EmployeeId> Exists<T>(this IRuleBuilder<T, EmployeeId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new EmployeeExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, DisciplineId> Exists<T>(this IRuleBuilder<T, DisciplineId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new DisciplineExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, SpecializationId> Exists<T>(this IRuleBuilder<T, SpecializationId> ruleBuilder, CollegeManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new SpecializationExistsValidator(context));
    }
}
