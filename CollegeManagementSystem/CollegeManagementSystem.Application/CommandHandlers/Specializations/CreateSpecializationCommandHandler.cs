using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations
{
    public sealed class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, SpecializationId>
    {
        public async Task<SpecializationId> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = Specialization.Create(request.Name);

            return specialization.Id;
        }
    }
}
