using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class DeleteGroupCommandHandler(ICollegeManagementSystemRepository repository, IValidator<DeleteGroupCommand> validator) : IRequestHandler<DeleteGroupCommand>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<DeleteGroupCommand> validator = validator;

    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var group = repository.Groups.Single(g => g.Id == request.GroupId);

        group.Delete();
    }
}
