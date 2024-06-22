namespace SmartCollege.SSO.Models
{
    public record AccountInformationDto(string Email, IReadOnlyCollection<string> Roles);
}
