using CollegeManagementSystem.Application.Queries.Employees;
using CollegeManagementSystem.Domain.Helpers;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Employees;
using SharedKernel.DTOs.Posts;

namespace CollegeManagementSystem.Application.QueryHandlers.Employees;

public sealed class GetEmployeeQueryHandler(IUnitOfWork unitOfWork, IValidator<GetEmployeeQuery> validator) : IRequestHandler<GetEmployeeQuery, EmployeeDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetEmployeeQuery> validator = validator;

    async Task<EmployeeDTO> IRequestHandler<GetEmployeeQuery, EmployeeDTO>.Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = unitOfWork.Repository.Employees.Single(e => e.Id == request.EmployeeId);

        return new EmployeeDTO
        {
            Id = employee.Id.Value,
            FirstName = employee.FirstName,
            MiddleName = employee.MiddleName,
            LastName = employee.LastName,
            //Posts = employee.Roles.Select(x => new PostDTO
            //{
            //    Id = (int)x,
            //    Name = x.GetDisplayName()!
            //})
            //.ToArray(),
            Blocked = employee.Blocked,
        };
    }
}