using MediatR;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.Projects;

namespace ProjectManagementSystem.Application.Queries.Projects;

public class GetProjectWorkAssignmentQuery : IRequest<FileDTO>
{
    public ProjectId ProjectId { get; init; }
}
