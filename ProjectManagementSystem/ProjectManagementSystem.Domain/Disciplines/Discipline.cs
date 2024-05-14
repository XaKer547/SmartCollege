using SharedKernel;

namespace ProjectManagementSystem.Domain.Disciplines;

public sealed class Discipline : Entity<DisciplineId>
{
    private Discipline() { }
    public string Name { get; private set; }
}
