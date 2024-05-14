using SharedKernel;

namespace ProjectManagementSystem.Domain.Specializations;

public sealed class SpecializationId : EntityId
{
    public SpecializationId(Guid id) : base(id) { }
    public SpecializationId() : base() { }
}
