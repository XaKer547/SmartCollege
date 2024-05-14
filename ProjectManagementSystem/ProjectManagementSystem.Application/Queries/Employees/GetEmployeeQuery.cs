using MediatR;
using ProjectManagementSystem.Domain.Employees;
using SharedKernel.DTOs.Employees;

namespace ProjectManagementSystem.Application.Queries.Employees;

public sealed record GetEmployeeQuery : IRequest<EmployeeDTO>
{
    public EmployeeId EmployeeId { get; init; }
}
