namespace SharedKernel.DTOs.Groups;

public sealed record GroupDTO
{
    public Guid GroupId { get; init; }
    public string Name { get; init; }
    public Guid SpecializationId { get; init; }
}
