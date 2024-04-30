using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Application.Repositories.Students;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class GraduateStudentCommandHandler(IStudentReadOnlyRepository repository) : IRequestHandler<GraduateStudentCommand>
{
    public async Task Handle(GraduateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await repository.GetStudentAsync(request.StudentId);

        student.Graduate(request.Graduated);
    }
}
