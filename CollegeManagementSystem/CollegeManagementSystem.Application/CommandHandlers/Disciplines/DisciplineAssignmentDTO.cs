namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public sealed record DisciplineAssignmentDTO
{
    public Guid DisciplineId { get; init; }
    public Guid EmployeeId { get; init; }
}
