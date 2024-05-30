using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace ProjectManagementSystem.API.Validators.Students;

public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
{
    public GetStudentQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);
    }
}
