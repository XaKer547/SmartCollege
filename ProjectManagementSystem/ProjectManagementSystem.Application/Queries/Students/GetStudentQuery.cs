using MediatR;
using ProjectManagementSystem.Domain.Students;
using SharedKernel.DTOs.Students;

namespace ProjectManagementSystem.Application.Queries.Students;

public sealed record GetStudentQuery : IRequest<StudentDTO>
{
    public StudentId StudentId { get; init; }
}
