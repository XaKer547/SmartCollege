using CollegeManagementSystem.Application.Queries.Students;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.Application.QueryHandlers.Students;

public sealed class GetStudentQueryHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<GetStudentQuery, StudentDTO>
{
    private readonly ICollegeManagementSystemRepository repository = repository;

    public Task<StudentDTO> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = repository.Students.SingleOrDefault(s => s.Id == request.StudentId);

        return Task.FromResult(new StudentDTO()
        {
            Id = student.Id.Value,
            FirstName = student.Firstname,
            MiddleName = student.Middlename,
            LastName = student.Lastname,
            Graduated = student.Graduated,
            GroupName = student.Group.Name,
        });
    }
}
