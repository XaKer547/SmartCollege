using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Domain.Posts;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class UpdateEmployeeCommandHandler(ICollegeManagementSystemRepository repository, IValidator<UpdateEmployeeCommand> validator) : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<UpdateEmployeeCommand> validator = validator;

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var employee = repository.Employees.Single(e => e.Id == request.EmployeeId);

        Post[] posts = [.. repository.Posts.Where(p => request.Posts.Contains(p.Id))];

        employee.Update(request.FirstName, request.MiddleName, request.LastName, request.Blocked, posts, request.Email);
    }
}
