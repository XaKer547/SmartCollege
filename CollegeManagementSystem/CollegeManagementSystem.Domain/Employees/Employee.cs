using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Users;
using CollegeManagementSystem.Domain.Users.Events;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : User<EmployeeId>
{
    private Employee()
    {
        Id = new EmployeeId();
    }

    public static Employee Create(string firstName, string middleName, string lastName)
    {
        var employee = new Employee()
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
        };

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

    public void Block(string password, Roles[] roles, bool blocked)
    {
        Blocked = blocked;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);

        //UpdateAccount(password, Roles, Blocked);
    }

    public void Delete()
    {
        DeleteAccount();

        var employeeDeletedEvent = new EmployeeDeletedEvent(Id);

        AddEvent(employeeDeletedEvent);
    }
}