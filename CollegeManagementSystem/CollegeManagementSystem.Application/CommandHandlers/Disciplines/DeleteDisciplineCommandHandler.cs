using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class DeleteDisciplineCommandHandler(ICollegeManagementSystemRepository repository,
    IValidator<DeleteDisciplineCommand> validator) : IRequestHandler<DeleteDisciplineCommand>
{
    private readonly ICollegeManagementSystemRepository _repository = repository;
    private readonly IValidator<DeleteDisciplineCommand> validator = validator;

    public async Task Handle(DeleteDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var discipline = _repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        discipline.Delete();
    }
}