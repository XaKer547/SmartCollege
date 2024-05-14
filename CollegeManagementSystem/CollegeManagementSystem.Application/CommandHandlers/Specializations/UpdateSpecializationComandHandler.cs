using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class UpdateSpecializationComandHandler(ICollegeManagementSystemRepository repository, IValidator<UpdateSpecializationCommand> validator) : IRequestHandler<UpdateSpecializationCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<UpdateSpecializationCommand> validator = validator;

    public async Task Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var specialization = repository.Specializations.Single(s => s.Id == request.SpecializationId);

        specialization.Update(request.Name);
    }
}
