using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups
{
    public sealed class UpdateGroupCommandHandler(ICollegeManagementSystemRepository repository, IValidator<UpdateGroupCommand> validator) : IRequestHandler<UpdateGroupCommand>
    {
        private readonly ICollegeManagementSystemRepository repository = repository;
        private readonly IValidator<UpdateGroupCommand> validator = validator;

        public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var specialization = repository.Specializations.Single(s => s.Id == request.SpecializationId);

            var group = repository.Groups.Single(g => g.Id == request.GroupId);

            group.Update(request.Name, specialization);
        }
    }
}
