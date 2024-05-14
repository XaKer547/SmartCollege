using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class GraduateStudentCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<GraduateStudentCommand>
{
    public Task Handle(GraduateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = repository.Students.SingleOrDefault(s => s.Id == request.StudentId);

        student.Graduate(request.Graduated);

        return Task.CompletedTask;
    }
}
