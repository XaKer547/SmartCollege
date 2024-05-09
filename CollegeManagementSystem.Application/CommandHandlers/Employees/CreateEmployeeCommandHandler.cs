using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class CreateEmployeeCommandHandler(IMediator mediator) : IRequestHandler<CreateEmployeeCommand, EmployeeId>
{
    private readonly IMediator _mediator = mediator;
    public async Task<EmployeeId> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Employee.Create();

        await _mediator.Publish(employee, cancellationToken);

        return employee.Id;
    }
}
