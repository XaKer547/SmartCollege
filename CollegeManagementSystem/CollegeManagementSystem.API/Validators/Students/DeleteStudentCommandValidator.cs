using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Students;

public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);
    }
}
