using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class CreateStudentCommandHandler(ICollegeManagementSystemRepository repository, IValidator<CreateStudentCommand> validator) : IRequestHandler<CreateStudentCommand, StudentId>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<CreateStudentCommand> validator = validator;

    public async Task<StudentId> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var group = repository.Groups.Single(g => g.Id == request.GroupId);

        var student = Student.Create(request.FirstName, request.MiddleName, request.LastName, group);

        return student.Id;
    }
}
