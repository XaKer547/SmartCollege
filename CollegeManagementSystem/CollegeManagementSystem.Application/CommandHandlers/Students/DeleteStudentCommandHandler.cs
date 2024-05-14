using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed record DeleteStudentCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<DeleteStudentCommand>
{
    public Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = repository.Students.SingleOrDefault(s => s.Id == request.StudentId);

        student.Delete();

        return Task.CompletedTask;
    }
}
