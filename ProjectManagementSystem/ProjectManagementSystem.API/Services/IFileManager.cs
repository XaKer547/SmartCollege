using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.API.Services;

public interface IFileManager
{
    Task<Guid> SaveFile(ProjectStageId projectStageId, IFormFile file);
    Task<Guid[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<IFormFile> files);
}
