using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class UpdateStudentCommandHandler(ICollegeManagementSystemRepository repository, IValidator<UpdateStudentCommand> validator) : IRequestHandler<UpdateStudentCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<UpdateStudentCommand> validator = validator;

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = repository.Students.Single(s => s.Id == request.StudentId);

        var group = repository.Groups.Single(g => g.Id == request.GroupId);

        student.Update(request.FirstName, request.MiddleName, request.LastName, group);
    }
}
