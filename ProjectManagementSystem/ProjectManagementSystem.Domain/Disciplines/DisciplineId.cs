using SharedKernel;

namespace ProjectManagementSystem.Domain.Disciplines;

public sealed class DisciplineId : EntityId
{
    public DisciplineId(Guid id) : base(id) { }
    public DisciplineId() : base() { }
}