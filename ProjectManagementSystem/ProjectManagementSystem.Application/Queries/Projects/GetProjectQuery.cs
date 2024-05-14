using MediatR;
using ProjectManagementSystem.Domain.Projects;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.Queries.Projects;

public sealed record GetProjectQuery : IRequest<ProjectDTO>
{
    public ProjectId ProjectId { get; init; }
}
