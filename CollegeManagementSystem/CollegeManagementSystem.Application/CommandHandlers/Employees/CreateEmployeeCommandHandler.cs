using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class CreateEmployeeCommandHandler(IMediator mediator, ICollegeManagementSystemRepository repository) : IRequestHandler<CreateEmployeeCommand, EmployeeId>
{
    private readonly IMediator _mediator = mediator;
    private readonly ICollegeManagementSystemRepository repository = repository;

    public async Task<EmployeeId> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var posts = repository.Posts.Where(p => request.Posts.Contains(p.Id))
            .ToArray();

        var employee = Employee.Create(request.FirstName, request.MiddleName, request.LastName, posts, request.Email);

        await _mediator.Publish(employee, cancellationToken);

        return employee.Id;
    }
}