using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Queries.Groups;
using ProjectManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace ProjectManagementSystem.API.Validators.Grops;

public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
{
    public GetGroupQueryValidator(ProjectManagementSystemDbContext context)
    {
        When(x => x.GroupId is not null, () =>
        {
            RuleFor(x => x.GroupId)
                .Exists(context);
        });
    }
}