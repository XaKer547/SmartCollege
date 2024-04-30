using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Application.Repositories.Groups;
using CollegeManagementSystem.Application.Repositories.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups
{
    public sealed class UpdateGroupCommandHandler(IGroupReadOnlyRepository groupRepository,
        ISpecializationReadOnlyRepository specializationRepository) : IRequestHandler<UpdateGroupCommand>
    {
        public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var specialization = await specializationRepository.GetSpecializationAsync(request.SpecializationId);

            var group = await groupRepository.GetGroupAsync(request.GroupId);

            group.Update(request.Name, specialization);
        }
    }
}
