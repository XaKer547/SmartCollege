using CollegeManagementSystem.Application.Queries.Disciplines;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Disciplines;

namespace CollegeManagementSystem.Application.QueryHandlers.Disciplines;

public sealed class GetDisciplinesQueryHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<GetDisciplinesQuery, IReadOnlyCollection<DisciplineDTO>>
{
    public Task<IReadOnlyCollection<DisciplineDTO>> Handle(GetDisciplinesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<DisciplineDTO> disciplines = [.. repository.Disciplines.Select(d => new DisciplineDTO
        {
            Id = d.Id.Value,
            Name = d.Name,
        })];

        return Task.FromResult(disciplines);
    }
}
