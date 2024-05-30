using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.Students;

public class StudentExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<StudentId, Student>(context)
{

}
