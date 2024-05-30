namespace ProjectManagementSystem.Application.Models;

public sealed record FileDTO
{
    public byte[] File { get; init; }
    public string Name { get; init; }
}
