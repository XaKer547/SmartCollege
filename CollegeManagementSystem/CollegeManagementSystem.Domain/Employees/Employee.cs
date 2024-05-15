using CollegeManagementSystem.Domain.Employees.Events;
using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : Entity<EmployeeId>
{
    private Employee() { }
    public EmployeeId Id { get; init; }
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public bool Blocked { get; private set; }
    public Roles[] Roles { get; private set; }
    public string Email { get; private set; }
    public static Employee Create(string firstName, string middleName, string lastName, Roles[] posts, string email)
    {
        var employee = new Employee()
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Email = email,
            Roles = posts
        };

        var employeeCreatedEvent = new EmployeeCreatedEvent()
        {
            Employee = employee
        };

        employee.AddEvent(employeeCreatedEvent);

        return employee;
    }
    public void Update(string firstName, string middlename, string lastName, bool blocked, Roles[] posts, string email)
    {
        Roles = posts;

        FirstName = firstName;
        MiddleName = middlename;
        LastName = lastName;
        Email = email;
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
