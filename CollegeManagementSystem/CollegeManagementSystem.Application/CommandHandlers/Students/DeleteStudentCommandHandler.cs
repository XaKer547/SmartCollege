using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed record DeleteStudentCommandHandler(ICollegeManagementSystemRepository repository, IValidator<DeleteStudentCommand> validator) : IRequestHandler<DeleteStudentCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<DeleteStudentCommand> validator = validator;

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = repository.Students.Single(s => s.Id == request.StudentId);

        student.Delete();
    }
}
