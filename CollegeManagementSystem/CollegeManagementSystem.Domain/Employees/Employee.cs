using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Users;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : User<EmployeeId>
{
    private Employee()
    {
        Id = new EmployeeId();
    }

    public static Employee Create(string firstName, string middleName, string lastName, Roles[] posts, string email)
    {
        var employee = new Employee()
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Email = email,
            Posts = posts
        };

        var employeeCreatedEvent = new EmployeeCreatedEvent(employee);

        employee.AddEvent(employeeCreatedEvent);

        return employee;
    }
    public void Update(string firstName, string middlename, string lastName)
    {
        FirstName = firstName;
        MiddleName = middlename;
        LastName = lastName;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);
    }
    public void Update(string password, Roles[] roles, bool blocked)
    {
        Posts = roles;
        Blocked = blocked;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);

        UpdateAccount(password, Posts, Blocked);
    }
    public void Delete()
    {
        DeleteAccount();

        var employeeDeletedEvent = new EmployeeDeletedEvent(Email);

        AddEvent(employeeDeletedEvent);
    }
}