using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class DisciplineExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<DisciplineId, Discipline>(context)
{

}
