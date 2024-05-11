using CollegeManagementSystem.Infrastucture.Data;
using FluentValidation;
using SharedKernel;

namespace CollegeManagementSystem.API.Validators;

public class EntityExistsValidator<TEntityId, TEntity> : AbstractValidator<TEntityId>
    where TEntityId : EntityId
    where TEntity : Entity<TEntityId>
{
    public EntityExistsValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x)
            .NotNull()
            .Must(x => context.Set<TEntity>().Any(e => e.Id == x));
    }
}
