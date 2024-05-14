using MediatR;
using ProjectManagementSystem.Domain.Groups;
using SharedKernel.DTOs.Students;

namespace ProjectManagementSystem.Application.Queries.Students;

public sealed record GetStudentsQuery : IRequest<IReadOnlyCollection<StudentDTO>>
{
    public GroupId GroupId { get; init; }
}
