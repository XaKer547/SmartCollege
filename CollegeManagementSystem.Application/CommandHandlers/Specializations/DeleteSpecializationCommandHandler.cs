using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Application.Repositories.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class DeleteSpecializationCommandHandler(ISpecializationReadOnlyRepository repository) : IRequestHandler<DeleteSpecializationCommand>
{
    public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = await repository.GetSpecializationAsync(request.SpecializationId);

        specialization.Delete();
    }
}
