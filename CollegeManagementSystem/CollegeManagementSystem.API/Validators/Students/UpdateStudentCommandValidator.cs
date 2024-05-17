using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        When(x => x.GroupId is not null, () =>
        {
            RuleFor(x => x.GroupId!)
            .Exists(context);
        });
    }
}
