using CollegeManagementSystem.Application.Queries.Disciplines;
using CollegeManagementSystem.Application.Repositories.Disciplines;
using MediatR;
using SharedKernel.DTOs.Disciplines;

namespace CollegeManagementSystem.Application.QueryHandlers.Disciplines;

public sealed class GetDisciplinesQueryHandler(IDisciplineReadOnlyRepository repository) : IRequestHandler<GetDisciplinesQuery, IReadOnlyCollection<DisciplineDTO>>
{
    public async Task<IReadOnlyCollection<DisciplineDTO>> Handle(GetDisciplinesQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetDisciplinesAsync();
    }
}
