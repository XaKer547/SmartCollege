namespace ProjectManagementSystem.Application.Models;

public sealed record FileDTO
{
    public byte[] FIle { get; init; }
    public string Name { get; init; }
}
