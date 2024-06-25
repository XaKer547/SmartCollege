namespace SmartCollege.SSO.Models.Accounts.Representativies
{
    public record CreateRepresentativeOfCompanyDto(string MiddleName,
        string FirstName,
        string LastName,
        string Phone,
        string Company,
        CreateRepresentativeOfCompanyAccountDto Account);

    public record CreateRepresentativeOfCompanyAccountDto(
        string Email,
        string Password);
}
