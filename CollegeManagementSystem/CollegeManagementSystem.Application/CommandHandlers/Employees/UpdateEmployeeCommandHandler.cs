using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class UpdateEmployeeCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<UpdateEmployeeCommand>
{
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = repository.Employees.SingleOrDefault(e => e.Id == request.EmployeeId);

        var posts = repository.Posts.Where(p => request.Posts.Contains(p.Id))
            .ToArray();

        employee.Update(request.FirstName, request.MiddleName, request.LastName, request.Blocked, [.. posts], request.Email);
    }
}
