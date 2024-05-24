using MediatR;
using ProjectManagementSystem.Domain.Projects;

namespace ProjectManagementSystem.Application.Commands.Projects;

public sealed record CompleteProjectCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
}
