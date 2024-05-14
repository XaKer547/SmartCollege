using CollegeManagementSystem.Domain.Groups;
using MediatR;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.Application.Queries.Groups;

public sealed record GetGroupStudentsQuery : IRequest<IReadOnlyCollection<StudentDTO>>
{
    public GroupId GroupId { get; init; }
}
