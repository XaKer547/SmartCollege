using CollegeManagementSystem.Domain.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Employees;

public sealed record CreateEmployeeCommand : IRequest<EmployeeId>
{


}
