using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Specializations;

public class DeleteSpecializationCommandValidator : AbstractValidator<DeleteSpecializationCommand>
{
    public DeleteSpecializationCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.SpecializationId)
            .Exists(context);
    }
}