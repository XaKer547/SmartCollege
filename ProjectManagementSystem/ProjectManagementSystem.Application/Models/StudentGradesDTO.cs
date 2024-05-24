namespace ProjectManagementSystem.Application.Models;

public sealed record StudentGradesDTO
{
    public string StudentFullName { get; init; }
    public int Grade { get; init; }
}
