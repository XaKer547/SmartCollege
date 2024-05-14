using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class DeleteSpecializationCommandHandler(ICollegeManagementSystemRepository repository, IValidator<DeleteSpecializationCommand> validator) : IRequestHandler<DeleteSpecializationCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<DeleteSpecializationCommand> validator = validator;

    public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var specialization = repository.Specializations.Single(s => s.Id == request.SpecializationId);

        specialization.Delete();
    }
}
