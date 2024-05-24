namespace ProjectManagementSystem.Application.Models;

public sealed record StudentWorkAssignmentDTO
{
    public string StudentFullName { get; init; }
    public string WorkName { get; init; }
}
