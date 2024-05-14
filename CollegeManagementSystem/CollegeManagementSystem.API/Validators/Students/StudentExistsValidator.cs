using CollegeManagementSystem.Domain.Students;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Validators.Students;

public class StudentExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<StudentId, Student>(context)
{

}
