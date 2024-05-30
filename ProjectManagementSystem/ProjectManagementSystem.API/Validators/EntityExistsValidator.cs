using FluentValidation;
using ProjectManagementSystem.Infrastucture.Common;
using SharedKernel;

namespace ProjectManagementSystem.API.Validators;

public abstract class EntityExistsValidator<TEntityId, TEntity> : AbstractValidator<TEntityId>
    where TEntityId : EntityId
    where TEntity : Entity<TEntityId>
{
    public EntityExistsValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x)
            .NotNull()
            .Must(x => context.Set<TEntity>()
            .Any(e => e.Id == x))
            .WithMessage($"Объект c таким идентификатором не найден или не существует")
            .WithErrorCode("404");
    }
}