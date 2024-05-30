using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.Employees;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Employees;
using SharedKernel.DTOs.Posts;

namespace ProjectManagementSystem.Application.QueryHandlers.Employees;

public sealed class GetEmployeeQueryHandler(IProjectManagementSystemRepository repository, IValidator<GetEmployeeQuery> validator) : IRequestHandler<GetEmployeeQuery, EmployeeDTO>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<GetEmployeeQuery> validator = validator;

    async Task<EmployeeDTO> IRequestHandler<GetEmployeeQuery, EmployeeDTO>.Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = repository.Employees.Select(e => new EmployeeDTO
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
        }).Single(e => e.Id == request.EmployeeId.Value);

        return employee;
    }
}
