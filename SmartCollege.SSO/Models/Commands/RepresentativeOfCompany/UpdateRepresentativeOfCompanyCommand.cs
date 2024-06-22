using MediatR;

namespace SmartCollege.SSO.Models.Commands.RepresentativeOfCompany
{
    public record UpdateRepresentativeOfCompanyCommand(
        string? MiddleName,
        string? FirstName,
        string? LastName,
        string? Phone,
        string? Company,
        UpdateRepresentativeOfCompanyAccountDto Account) : IRequest<HandleResult>;

    public record UpdateRepresentativeOfCompanyWithEmailCommand(
        string CurrentEmail,
        UpdateRepresentativeOfCompanyCommand Origin) : UpdateRepresentativeOfCompanyCommand(Origin);
}
