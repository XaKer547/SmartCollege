using CollegeManagementSystem.Domain.Students;

namespace CollegeManagementSystem.Application.Repositories.Students;

public interface IStudentReadOnlyRepository
{
    Task<Student> GetStudentAsync(StudentId studentId);
}
