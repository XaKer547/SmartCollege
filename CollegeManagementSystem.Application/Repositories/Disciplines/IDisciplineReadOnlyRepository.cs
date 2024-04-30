using CollegeManagementSystem.Domain.Disciplines;
using SharedKernel.DTOs.Disciplines;

namespace CollegeManagementSystem.Application.Repositories.Disciplines;

public interface IDisciplineReadOnlyRepository
{
    Task<IReadOnlyCollection<DisciplineDTO>> GetDisciplinesAsync();
    Task<Discipline> GetDisciplineAsync(DisciplineId disciplineId);
}
