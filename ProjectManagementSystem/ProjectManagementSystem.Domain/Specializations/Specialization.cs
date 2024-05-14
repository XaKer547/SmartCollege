using SharedKernel;

namespace ProjectManagementSystem.Domain.Specializations;

public sealed class Specialization : Entity<SpecializationId>
{
    private Specialization() { }
    public string Name { get; private set; }
}
