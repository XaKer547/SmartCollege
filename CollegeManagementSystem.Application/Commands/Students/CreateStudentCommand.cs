using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Students;

public sealed record CreateStudentCommand : IRequest<StudentId>
{
    public GroupId GroupId { get; init; }
    public string Firstname { get; init; }
    public string Middleame { get; init; }
    public string LastName { get; init; }
}
