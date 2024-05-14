using MediatR;
using SharedKernel.DTOs.Employees;

namespace ProjectManagementSystem.Application.Queries.Employees;

public sealed record GetEmployeesQuery : IRequest<IReadOnlyCollection<EmployeeDTO>>
{

}
