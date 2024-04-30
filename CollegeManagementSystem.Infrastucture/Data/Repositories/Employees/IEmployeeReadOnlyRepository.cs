using CollegeManagementSystem.Domain.Employees;

namespace CollegeManagementSystem.Application.Repositories.Employees;

public interface IEmployeeReadOnlyRepository
{
    Task<Employee> GetEmployeeAsync(EmployeeId employeeId);
}
