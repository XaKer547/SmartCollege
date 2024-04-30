using CollegeManagementSystem.Domain.Employees.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class Employee : Entity
{
    private Employee() { }
    public EmployeeId Id { get; init; }
    public string Firstname { get; private set; }
    public string Middlename { get; private set; }
    public string Lastname { get; private set; }
    public bool Blocked { get; private set; }
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
    public void Update()
    {
        throw new NotImplementedException();
    }
    public void Delete()
    {
        var employeeDeletedEvent = new EmployeeDeletedEvent()
        {
            EmployeeId = Id
        };

        AddEvent(employeeDeletedEvent);
    }
}
