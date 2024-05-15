using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.MiddleName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.GroupId)
            .Exists(context);
    }
}
