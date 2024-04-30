using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Application.Repositories.Groups;
using CollegeManagementSystem.Application.Repositories.Students;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Students;

public sealed class UpdateEmployeeCommandHandler(IStudentReadOnlyRepository studentRepository,
    IGroupReadOnlyRepository groupRepository) : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetStudentAsync(request.StudentId);

        var group = await groupRepository.GetGroupAsync(request.GroupId);

        student.Update(request.Firstname, request.Middlename, request.Lastname, group);
    }
}
