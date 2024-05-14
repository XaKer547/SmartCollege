using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class DeleteEmployeeCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<DeleteEmployeeCommand>
{
    public Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = repository.Employees.SingleOrDefault(e => e.Id == request.EmployeeId);

        employee.Delete();

        return Task.CompletedTask;
    }
}
