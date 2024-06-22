using MediatR;

namespace SmartCollege.SSO.Models.Queries
{
    public record GetAccountQuery(string UserId) : IRequest<HandleResult<AccountInformationDto>>;
}
