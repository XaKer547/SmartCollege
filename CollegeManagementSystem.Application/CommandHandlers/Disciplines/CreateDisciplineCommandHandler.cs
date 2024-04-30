using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Application.Repositories.Disciplines;
using CollegeManagementSystem.Domain.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.RequestHandlers.Disciplines
{
    public class CreateDisciplineCommandHandler(IDisciplineWriteOnlyRepository repository) : IRequestHandler<CreateDisciplineCommand, DisciplineId>
    {
        public async Task<DisciplineId> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
        {
            var dicipline = Discipline.Create(request.Name);

            await repository.AddAsync(dicipline, cancellationToken);

            return dicipline.Id;
        }
    }
}
