using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public sealed record UpdateDisciplineCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<UpdateDisciplineCommand>
{
    private readonly ICollegeManagementSystemRepository _repository = repository;
    public Task Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
    {
        var discipline = _repository.Disciplines.SingleOrDefault(d => d.Id == request.DisciplineId);

        discipline.Update(request.Name);

        return Task.CompletedTask;
    }
}
