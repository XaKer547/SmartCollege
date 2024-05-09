using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class DeleteDisciplineCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<DeleteDisciplineCommand>
{
    private readonly ICollegeManagementSystemRepository _repository = repository;
    public Task Handle(DeleteDisciplineCommand request, CancellationToken cancellationToken)
    {
        var discipline = _repository.Disciplines.SingleOrDefault(d => d.Id == request.DisciplineId);

        discipline.Delete();

        return Task.CompletedTask;
    }
}
