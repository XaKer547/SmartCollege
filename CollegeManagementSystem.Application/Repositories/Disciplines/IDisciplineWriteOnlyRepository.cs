using CollegeManagementSystem.Domain.Disciplines;

namespace CollegeManagementSystem.Application.Repositories.Disciplines;

public interface IDisciplineWriteOnlyRepository
{
    Task AddAsync(Discipline discipline, CancellationToken cancellationToken);
    Task DeleteAsync(DisciplineId disciplineId, CancellationToken cancellationToken);
    Task UpdateAsync(Discipline discipline, CancellationToken cancellationToken);
}
