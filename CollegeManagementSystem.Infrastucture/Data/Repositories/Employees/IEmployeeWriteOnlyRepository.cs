using CollegeManagementSystem.Domain.Employees;

namespace CollegeManagementSystem.Application.Repositories.Employees;

public interface IEmployeeWriteOnlyRepository
{
    Task<Employee> GetEmployeeAsync(EmployeeId employeeId);
}
