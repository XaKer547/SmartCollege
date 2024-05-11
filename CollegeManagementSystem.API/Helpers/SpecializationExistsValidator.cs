using CollegeManagementSystem.API.Validators;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Helpers
{
    public class SpecializationExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<SpecializationId, Specialization>(context)
    {

    }
}
