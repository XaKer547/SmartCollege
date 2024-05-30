using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;
using SharedKernel.DTOs.Students;

namespace ProjectManagementSystem.Application.QueryHandlers.Students;

public sealed class GetStudentsQueryHandler(IUnitOfWork unitOfWork, IValidator<GetStudentsQuery> validator) : IRequestHandler<GetStudentsQuery, IReadOnlyCollection<StudentDTO>>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetStudentsQuery> validator = validator;

    public async Task<IReadOnlyCollection<StudentDTO>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        IReadOnlyCollection<StudentDTO> students = [.. unitOfWork.Repository.Students.Where(s => s.Group.Id == request.GroupId)
            .Select(s => new StudentDTO
            {
                Id = s.Id.Value,
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                Graduated = s.Graduated,
            })];

        return students;
    }
}
