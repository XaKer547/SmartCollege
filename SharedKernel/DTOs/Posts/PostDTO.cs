namespace SharedKernel.DTOs.Posts;

public sealed record PostDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}
