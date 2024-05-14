using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class DeleteSpecializationCommandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<DeleteSpecializationCommand>
{
    public Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = repository.Specializations.SingleOrDefault(s => s.Id == request.SpecializationId);

        specialization.Delete();

        return Task.CompletedTask;
    }
}
