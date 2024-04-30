using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Application.Repositories.Groups;
using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class CreateStudentCommandHandler(IGroupReadOnlyRepository repository) : IRequestHandler<CreateStudentCommand, StudentId>
{
    public async Task<StudentId> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var group = await repository.GetGroupAsync(request.GroupId);

        var student = Student.Create(request.Firstname, request.Middleame, request.LastName, group);

        return student.Id;
    }
}
