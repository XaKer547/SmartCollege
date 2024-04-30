namespace SharedKernel.DTOs.Students;

public sealed record StudentDTO
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public string GroupName { get; init; }
    public bool Graduated { get; init; }
}
