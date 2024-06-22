using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;
using SmartCollege.SSO.Shared.Contracts;

namespace SmartCollege.SSO.Models.Events
{
    public abstract record UpdateAccountEvent<TContact> : INotification
    {
        public abstract TContact GetContact();
    }

    public record UpdateCollegeAccountEvent(
        Guid UserId,
        string[] Roles) : UpdateAccountEvent<IUserRolesUpdated>, IUserRolesUpdated
    {
        public override IUserRolesUpdated GetContact()
        {
            return this;
        }
    }

    public record UpdateRepresentativeAccountEvent(
        string Email,
        string FullName,
        string Phone,
        string Company) : CreateAccountEvent<IUpdateRepresentativeOfTheCompanyAccountContract>, IUpdateRepresentativeOfTheCompanyAccountContract
    {
        public override IUpdateRepresentativeOfTheCompanyAccountContract GetContact()
        {
            return this;
        }
    }
}
