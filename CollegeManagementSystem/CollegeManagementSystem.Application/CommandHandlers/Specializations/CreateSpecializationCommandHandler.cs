using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Specializations;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations
{
    public sealed class CreateSpecializationCommandHandler(IValidator<CreateSpecializationCommand> validator) : IRequestHandler<CreateSpecializationCommand, SpecializationId>
    {
        private readonly IValidator<CreateSpecializationCommand> validator = validator;

        public async Task<SpecializationId> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var specialization = Specialization.Create(request.Name);

            return specialization.Id;
        }
    }
}
