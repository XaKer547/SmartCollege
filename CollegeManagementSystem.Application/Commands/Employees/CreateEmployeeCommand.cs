using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Posts;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Employees;

public sealed record CreateEmployeeCommand : IRequest<EmployeeId>
{
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public bool Blocked { get; init; }
    public PostId[] Posts { get; init; }
    public string Email { get; init; }
}
