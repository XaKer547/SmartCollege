using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Queries.Groups;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Grops;

public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
{
    public GetGroupQueryValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.GroupId)
            .Exists(context);
    }
}