using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using SharedKernel.DTOs.Disciplines;

namespace CollegeManagementSystem.Application.Repositories.Disciplines;

public class DisciplineReadOnlyRepository(CollegeManagementSystemDbContext context) : IDisciplineReadOnlyRepository
{
    public async Task<Discipline> GetDisciplineAsync(DisciplineId disciplineId)
    {
        var discipline = await context.Disciplines.SingleOrDefaultAsync(d => d.Id == disciplineId);

        return discipline;
    }

    public async Task<IReadOnlyCollection<DisciplineDTO>> GetDisciplinesAsync()
    {
        var disciplines = await context.Disciplines.Select(d => new DisciplineDTO
        {
            Id = d.Id.Value,
            Name = d.Name,
        }).ToArrayAsync();

        return disciplines;
    }
}
