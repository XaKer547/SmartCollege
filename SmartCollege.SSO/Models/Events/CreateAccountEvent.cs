using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;
using SmartCollege.SSO.Shared.Contracts;

namespace SmartCollege.SSO.Models.Events
{
    public abstract record CreateAccountEvent<TContact> : INotification
    {
        public abstract TContact GetContact();
    }

    public record CreateCollegeAccountEvent(
        Guid UserId,
        string[] Roles) : CreateAccountEvent<IUserRolesUpdated>, IUserRolesUpdated
    {
        public override IUserRolesUpdated GetContact()
        {
            return this;
        }
    }

    public record CreateRepresentativeAccountEvent(
        string Email,
        string FullName,
        string Phone,
        string Company) : CreateAccountEvent<ICreateRepresentativeOfTheCompanyAccountContract>,  ICreateRepresentativeOfTheCompanyAccountContract
    {
        public override ICreateRepresentativeOfTheCompanyAccountContract GetContact()
    {
        return this;
    }
}
}
