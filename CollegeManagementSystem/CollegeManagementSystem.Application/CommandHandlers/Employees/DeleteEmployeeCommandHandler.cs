using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class DeleteEmployeeCommandHandler(ICollegeManagementSystemRepository repository, IValidator<DeleteEmployeeCommand> validator) : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<DeleteEmployeeCommand> validator = validator;

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = repository.Employees.Single(e => e.Id == request.EmployeeId);

        employee.Delete();
    }
}
