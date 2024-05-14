using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class UpdateSpecializationComandHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<UpdateSpecializationCommand>
{
    public Task Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = repository.Specializations.SingleOrDefault(s => s.Id == request.SpecializationId);

        specialization.Update(request.Name);

        return Task.CompletedTask;
    }
}
