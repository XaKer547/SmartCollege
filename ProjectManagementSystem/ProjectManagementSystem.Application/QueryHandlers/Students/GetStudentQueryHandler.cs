using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Students;

namespace ProjectManagementSystem.Application.QueryHandlers.Students;

public sealed class GetStudentQueryHandler(IProjectManagementSystemRepository repository, IValidator<GetStudentQuery> validator) : IRequestHandler<GetStudentQuery, StudentDTO>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<GetStudentQuery> validator = validator;

    public async Task<StudentDTO> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = repository.Students.Select(s => new StudentDTO
        {
            Id = s.Id.Value,
            FirstName = s.Firstname,
            MiddleName = s.Middlename,
            LastName = s.Lastname,
            Graduated = s.Graduated,
        }).Single(s => s.Id == request.StudentId.Value);

        return student;
    }
}