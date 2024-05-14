using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups
{
    public sealed class UpdateGroupCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<UpdateGroupCommand>
    {
        public Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var specialization = repository.Specializations.SingleOrDefault(s => s.Id == request.SpecializationId);

            var group = repository.Groups.SingleOrDefault(g => g.Id == request.GroupId);

            group.Update(request.Name, specialization);

            return Task.CompletedTask;
        }
    }
}
