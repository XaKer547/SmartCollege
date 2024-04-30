using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Application.Repositories.Students;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed record DeleteStudentCommandHandler(IStudentReadOnlyRepository Repository) : IRequestHandler<DeleteStudentCommand>
{
    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await Repository.GetStudentAsync(request.StudentId);

        student.Delete();
    }
}
