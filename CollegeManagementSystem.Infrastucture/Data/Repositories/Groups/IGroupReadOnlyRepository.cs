using CollegeManagementSystem.Domain.Groups;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.Repositories.Groups;

public interface IGroupReadOnlyRepository
{
    Task<Group> GetGroupAsync(GroupId groupId);
    Task<IReadOnlyCollection<GroupDTO>> GetGroupsAsync();
}
