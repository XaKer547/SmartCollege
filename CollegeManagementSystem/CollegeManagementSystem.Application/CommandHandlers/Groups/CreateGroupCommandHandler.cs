using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class CreateGroupCommandHandler(ICollegeManagementSystemRepository repository, IValidator<CreateGroupCommand> validator) : IRequestHandler<CreateGroupCommand, GroupId>
{
    private readonly ICollegeManagementSystemRepository repository = repository;
    private readonly IValidator<CreateGroupCommand> validator = validator;

    public async Task<GroupId> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var specialization = repository.Specializations.Single(s => s.Id == request.SpecializationId);

        var group = Group.Create(request.Name, specialization);

        return group.Id;
    }
}
