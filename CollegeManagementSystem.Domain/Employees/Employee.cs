using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Posts;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : Entity
{
    private Employee() { }
    public EmployeeId Id { get; init; }
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public bool Blocked { get; private set; }
    public Post[] Posts { get; private set; }
    public static Employee Create()
    {
        var employee = new Employee();

        var employeeCreatedEvent = new EmployeeCreatedEvent()
        {
            Employee = employee
        };

        employee.AddEvent(employeeCreatedEvent);

        return employee;
    }
    public void Update(string firstName, string middlename, string lastName, bool blocked, Post[] posts)
    {
        Posts = posts;

        FirstName = firstName;
        MiddleName = middlename;
        LastName = lastName;

        Blocked = blocked;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent()
        {
            Employee = this
        };

        AddEvent(employeeeUpdatedEvent);
    }
    public void Delete()
    {
        Deleted = true;

        var employeeDeletedEvent = new EmployeeDeletedEvent()
        {
            EmployeeId = Id
        };

        AddEvent(employeeDeletedEvent);
    }
}
