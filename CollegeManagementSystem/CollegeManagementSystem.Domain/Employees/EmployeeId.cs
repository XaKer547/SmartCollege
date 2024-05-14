using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees;

public sealed class EmployeeId : EntityId
{
    public EmployeeId() : base() { }
    public EmployeeId(Guid employeeId) : base(employeeId) { }
}
