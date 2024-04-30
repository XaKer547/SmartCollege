using CollegeManagementSystem.Application.Queries.Groups;
using MediatR;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupStudentsQueryHandler : IRequestHandler<GetGroupStudentsQuery, IReadOnlyCollection<StudentDTO>>
{
    public Task<IReadOnlyCollection<StudentDTO>> Handle(GetGroupStudentsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
