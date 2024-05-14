using CollegeManagementSystem.Domain.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.Queries.Employees;

public sealed record GetEmployeeQuery : IRequest
{
    public EmployeeId EmployeeId { get; init; }
}
