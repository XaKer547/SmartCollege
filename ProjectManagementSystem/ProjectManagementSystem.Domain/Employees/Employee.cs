using ProjectManagementSystem.Domain.Posts;
using SharedKernel;

namespace ProjectManagementSystem.Domain.Employees;

public sealed class Employee : Entity<EmployeeId>
{
    private Employee() { }
    public EmployeeId Id { get; init; }
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public bool Blocked { get; private set; }
    public Post[] Posts { get; private set; }
    public string Email { get; private set; }
}
