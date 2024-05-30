using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace ProjectManagementSystem.API.Validators.Students;

public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
{
    public GetStudentsQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.GroupId)
            .Exists(context);
    }
}
