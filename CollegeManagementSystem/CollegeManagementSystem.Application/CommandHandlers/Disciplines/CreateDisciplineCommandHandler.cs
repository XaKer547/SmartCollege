using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class CreateDisciplineCommandHandler : IRequestHandler<CreateDisciplineCommand, DisciplineId>
{
    public Task<DisciplineId> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
    {
        var dicipline = Discipline.Create(request.Name);

        return Task.FromResult(dicipline.Id);
    }
}
