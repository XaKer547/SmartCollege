using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Application.Repositories.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class UpdateEmployeeCommandHandler(IEmployeeWriteOnlyRepository repository) : IRequestHandler<UpdateEmployeeCommand>
{
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeAsync(request.EmployeeId);

        employee.Update();
    }
}
