using CollegeManagementSystem.Application.Repositories.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Disciplines;

public class DeleteDisciplineCommandHandler(IDisciplineWriteOnlyRepository repository) : IRequestHandler<DeleteDisciplineCommand>
{
    public async Task Handle(DeleteDisciplineCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.DisciplineId, cancellationToken);
    }
}
