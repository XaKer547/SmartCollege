using CollegeManagementSystem.Application.Helpers;
using CollegeManagementSystem.Application.Queries.Employees;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Employees;
using SharedKernel.DTOs.Posts;

namespace CollegeManagementSystem.Application.QueryHandlers.Employees;

public sealed class GetEmployeeQueryHandler(ICollegeManagementSystemRepository repository, IValidator<GetEmployeeQuery> validator) : IRequestHandler<GetEmployeeQuery, EmployeeDTO>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
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
            Posts = e.Roles.Select(p => new PostDTO
            {
                Id = (int)p,
                Name = p.GetDisplayName(),
            }).ToArray(),
            Blocked = e.Blocked,
        }).Single(e => e.Id == request.EmployeeId.Value);

        return employee;
    }
}