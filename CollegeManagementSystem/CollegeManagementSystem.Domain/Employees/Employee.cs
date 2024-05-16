﻿using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Users;
using CollegeManagementSystem.Domain.Users.Events;
using SharedKernel;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : User<EmployeeId>
{
    private Employee()
    {
        Id = new EmployeeId();
    }

    public Roles[] Roles { get; private set; }

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

        var employeeCreatedEvent = new EmployeeCreatedEvent(employee);

        employee.AddEvent(employeeCreatedEvent);

        return employee;
    }
    public void Update(string firstName, string middlename, string lastName, bool blocked)
    {
        FirstName = firstName;
        MiddleName = middlename;
        LastName = lastName;
        Blocked = blocked;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);
    }

    public void Update(string email, string password, Roles[] roles)
    {
        Roles = roles;

        var employeeeUpdatedEvent = new EmployeeUpdatedEvent(this);

        AddEvent(employeeeUpdatedEvent);

        UpdateAccount(email, password, roles);
    }

    public void Delete()
    {
        DeleteAccount();

        var employeeDeletedEvent = new EmployeeDeletedEvent(Id);

        AddEvent(employeeDeletedEvent);
    }
}