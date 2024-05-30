using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Validators.Grops;

public class GroupExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<GroupId, Group>(context)
{

}