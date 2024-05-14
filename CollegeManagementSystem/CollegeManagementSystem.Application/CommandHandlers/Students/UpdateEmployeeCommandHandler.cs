using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class UpdateEmployeeCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<UpdateStudentCommand>
{
    public Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = repository.Students.SingleOrDefault(s => s.Id == request.StudentId);

        var group = repository.Groups.SingleOrDefault(g => g.Id == request.GroupId);

        student.Update(request.Firstname, request.Middlename, request.Lastname, group);

        return Task.CompletedTask;
    }
}
