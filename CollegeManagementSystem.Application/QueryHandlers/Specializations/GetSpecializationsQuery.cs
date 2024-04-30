using MediatR;
using SharedKernel.DTOs.Specializations;

namespace CollegeManagementSystem.Application.QueryHandlers.Specializations;

public sealed record GetSpecializationsQuery : IRequest<IReadOnlyCollection<SpecializationDTO>>
{

}
