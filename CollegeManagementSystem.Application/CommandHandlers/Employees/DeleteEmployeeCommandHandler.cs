using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Application.Repositories.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class DeleteEmployeeCommandHandler(IEmployeeReadOnlyRepository repository) : IRequestHandler<DeleteEmployeeCommand>
{
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeAsync(request.EmployeeId);

        employee.Delete();
    }
}
