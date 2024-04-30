using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Application.Repositories.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class UpdateSpecializationComandHandler(ISpecializationReadOnlyRepository repository) : IRequestHandler<UpdateSpecializationCommand>
{
    public async Task Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = await repository.GetSpecializationAsync(request.SpecializationId);

        specialization.Update(request.Name);
    }
}
