using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Validators.Specializations;

public class SpecializationExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<SpecializationId, Specialization>(context)
{

}