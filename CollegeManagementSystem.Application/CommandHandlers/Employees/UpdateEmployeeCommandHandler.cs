using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Application.Repositories.Employees;
using CollegeManagementSystem.Application.Repositories.Posts;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Employees;

public sealed class UpdateEmployeeCommandHandler(IEmployeeWriteOnlyRepository employeeRepository, IPostReadOnlyRepository postRepository) : IRequestHandler<UpdateEmployeeCommand>
{
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetEmployeeAsync(request.EmployeeId);

        var posts = await postRepository.GetPostsById(request.Posts);

        employee.Update(request.FirstName, request.MiddleName, request.LastName, request.Blocked, [.. posts]);
    }
}
