using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Application.Repositories.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.RequestHandlers.Disciplines;

public sealed record UpdateDisciplineCommandHandler(IDisciplineReadOnlyRepository repository) : IRequestHandler<UpdateDisciplineCommand>
{
    public async Task Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
    {
        var discipline = await repository.GetDisciplineAsync(request.DisciplineId);
    }
}
