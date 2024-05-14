using MediatR;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStages;

public sealed record DeleteProjectStageCommand : IRequest
{
    public ProjectStageId ProjectStageId { get; init; }
}
