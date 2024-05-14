using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Disciplines;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class CreateDisciplineCommandHandler(IValidator<CreateDisciplineCommand> validator) : IRequestHandler<CreateDisciplineCommand, DisciplineId>
{
    private readonly IValidator<CreateDisciplineCommand> validator = validator;

    public async Task<DisciplineId> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var dicipline = Discipline.Create(request.Name);

        return dicipline.Id;
    }
}
