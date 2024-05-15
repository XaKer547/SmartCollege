using CollegeManagementSystem.Domain.Employees;
using MediatR;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Application.Commands.Employees;

public sealed record UpdateEmployeeCommand : IRequest
{
    public EmployeeId EmployeeId { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public bool Blocked { get; init; }
    public Roles[] Posts { get; init; }
}
