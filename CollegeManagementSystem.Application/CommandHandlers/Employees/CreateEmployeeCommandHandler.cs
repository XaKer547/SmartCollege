using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Application.Repositories.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class CreateEmployeeCommandHandler(IDisciplineWriteOnlyRepository repository) : IRequestHandler<CreateEmployeeCommand, EmployeeId>
{
    public async Task<EmployeeId> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Employee.Create();

        return employee.Id;
    }
}
