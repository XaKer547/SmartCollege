using MediatR;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.Queries.Projects;

public sealed record GetProjectsQuery : IRequest<IReadOnlyCollection<ProjectDTO>>
{

}
