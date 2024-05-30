using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class GetProjectStagesQueryValidator : AbstractValidator<GetProjectStagesQuery>
{
    public GetProjectStagesQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);
    }
}
