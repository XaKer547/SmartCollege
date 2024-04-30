using CollegeManagementSystem.Application.Queries.Students;
using CollegeManagementSystem.Application.Repositories.Students;
using MediatR;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.Application.QueryHandlers.Students;

public sealed class GetStudentQueryHandler(IStudentReadOnlyRepository repository) : IRequestHandler<GetStudentQuery, StudentDTO>
{
    public async Task<StudentDTO> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await repository.GetStudentAsync(request.StudentId);

        return new StudentDTO()
        {
            Id = student.Id.Value,
            FirstName = student.Firstname,
            MiddleName = student.Middlename,
            LastName = student.Lastname,
            Graduated = student.Graduated,
            GroupName = student.Group.Name,
        };
    }
}
