using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed class EmployeeDeletedEvent : IDomainEvent
{
    public EmployeeDeletedEvent(EmployeeId employeeId)
    {
        EmployeeId = employeeId;    
    }

    public  EmployeeId EmployeeId { get; init; }
}
