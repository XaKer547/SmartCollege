using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class GraduateStudentCommandHandler(ICollegeManagementSystemRepository repository, IValidator<GraduateStudentCommand> validator) : IRequestHandler<GraduateStudentCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<GraduateStudentCommand> validator = validator;

    public async Task Handle(GraduateStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = repository.Students.Single(s => s.Id == request.StudentId);

        student.Graduate(request.Graduated);
    }
}
