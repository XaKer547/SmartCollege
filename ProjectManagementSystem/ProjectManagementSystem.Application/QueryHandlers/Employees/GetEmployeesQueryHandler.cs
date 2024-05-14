using MediatR;
using ProjectManagementSystem.Application.Queries.Employees;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Employees;
using SharedKernel.DTOs.Posts;

namespace ProjectManagementSystem.Application.QueryHandlers.Employees;

public sealed class GetEmployeesQueryHandler(IProjectManagementSystemRepository repository) : IRequestHandler<GetEmployeesQuery, IReadOnlyCollection<EmployeeDTO>>
{
    private readonly IProjectManagementSystemRepository repository = repository;

    public Task<IReadOnlyCollection<EmployeeDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<EmployeeDTO> employees = [.. repository.Employees.Select(e => new EmployeeDTO
        {
            Id = e.Id.Value,
            FirstName = e.FirstName,
            MiddleName = e.MiddleName,
            LastName = e.LastName,
            Posts = e.Posts.Select(p => new PostDTO
            {
                Id = p.Id.Value,
                Name = p.Name,
            }).ToArray(),
            Blocked = e.Blocked,
        })];

        return Task.FromResult(employees);
    }
}
