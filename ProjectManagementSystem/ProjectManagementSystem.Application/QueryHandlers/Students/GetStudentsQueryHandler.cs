using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Students;

namespace ProjectManagementSystem.Application.QueryHandlers.Students;

public sealed class GetStudentsQueryHandler(IProjectManagementSystemRepository repository, IValidator<GetStudentsQuery> validator) : IRequestHandler<GetStudentsQuery, IReadOnlyCollection<StudentDTO>>
{
    private readonly IProjectManagementSystemRepository repository = repository;
    private readonly IValidator<GetStudentsQuery> validator = validator;

    public async Task<IReadOnlyCollection<StudentDTO>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        IReadOnlyCollection<StudentDTO> students = [.. repository.Students.Where(s => s.Group.Id == request.GroupId)
            .Select(s => new StudentDTO
            {
                Id = s.Id.Value,
                FirstName = s.Firstname,
                MiddleName = s.Middlename,
                LastName = s.Lastname,
                Graduated = s.Graduated,
            })];

        return students;
    }
}
