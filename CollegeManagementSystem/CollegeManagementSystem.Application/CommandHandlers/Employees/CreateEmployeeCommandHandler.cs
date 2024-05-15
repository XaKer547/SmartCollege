using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class CreateEmployeeCommandHandler(ICollegeManagementSystemRepository repository, IValidator<CreateEmployeeCommand> validator) : IRequestHandler<CreateEmployeeCommand, EmployeeId>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<CreateEmployeeCommand> validator = validator;

    public async Task<EmployeeId> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = Employee.Create(request.FirstName, request.MiddleName, request.LastName, request.Posts, request.Email);

        return employee.Id;
    }
}