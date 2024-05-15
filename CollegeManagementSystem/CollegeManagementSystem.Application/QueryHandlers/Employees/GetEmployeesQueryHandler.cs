using CollegeManagementSystem.Application.Helpers;
using CollegeManagementSystem.Application.Queries.Employees;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Employees;
using SharedKernel.DTOs.Posts;

namespace CollegeManagementSystem.Application.QueryHandlers.Employees;

public sealed class GetEmployeesQueryHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<GetEmployeesQuery, IReadOnlyCollection<EmployeeDTO>>
{
    private readonly ICollegeManagementSystemRepository repository = repository;

    public Task<IReadOnlyCollection<EmployeeDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<EmployeeDTO> employees = [.. repository.Employees.Select(e => new EmployeeDTO
        {
            Id = e.Id.Value,
            FirstName = e.FirstName,
            MiddleName = e.MiddleName,
            LastName = e.LastName,
            Posts = e.Roles.Select(p => new PostDTO
            {
                Id = (int)p,
                Name = p.GetDisplayName(),
            }).ToArray(),
            Blocked = e.Blocked,
        })];

        return Task.FromResult(employees);
    }
}
