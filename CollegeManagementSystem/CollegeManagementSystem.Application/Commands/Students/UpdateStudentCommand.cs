using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Students;

public sealed record UpdateStudentCommand : IRequest
{
    public StudentId StudentId { get; init; }
    public string Firstname { get; init; }
    public string Middlename { get; init; }
    public string Lastname { get; init; }
    public GroupId GroupId { get; init; }
}
