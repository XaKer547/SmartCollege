using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class CreateStudentCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<CreateStudentCommand, StudentId>
{
    public Task<StudentId> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var group = repository.Groups.SingleOrDefault(g => g.Id == request.GroupId);

        var student = Student.Create(request.FirstName, request.MiddleName, request.LastName, group);

        return Task.FromResult(student.Id);
    }
}
