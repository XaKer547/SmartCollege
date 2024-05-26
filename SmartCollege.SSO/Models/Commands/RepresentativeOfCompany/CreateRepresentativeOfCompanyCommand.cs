using MediatR;
using SmartCollege.SSO.Models.Commands.Account;

namespace SmartCollege.SSO.Models.Commands.RepresentativeOfCompany
{
    public record CreateRepresentativeOfCompanyCommand(
        string MiddleName,
        string FirstName,
        string LastName,
        string Phone,
        string Company,
        CreateRepresentativeOfCompanyAccountCommand Account) : IRequest<HandleResult>;
}
