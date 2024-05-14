using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public sealed record UpdateDisciplineCommandHandler(ICollegeManagementSystemRepository repository, IValidator<UpdateDisciplineCommand> validator) : IRequestHandler<UpdateDisciplineCommand>
{
    private readonly ICollegeManagementSystemRepository _repository = repository;
    private readonly IValidator<UpdateDisciplineCommand> validator = validator;

    public async Task Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var discipline = _repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        discipline.Update(request.Name);
    }
}