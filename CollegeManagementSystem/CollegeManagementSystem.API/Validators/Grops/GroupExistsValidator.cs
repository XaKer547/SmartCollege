using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Validators.Grops;

public class GroupExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<GroupId, Group>(context)
{

}