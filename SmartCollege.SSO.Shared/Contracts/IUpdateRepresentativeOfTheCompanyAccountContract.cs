namespace SmartCollege.SSO.Shared.Contracts
{
    public interface IUpdateRepresentativeOfTheCompanyAccountContract
    {
        string Email { get; }

        string FullName { get; }

        string Phone { get; }

        string Company { get; }
    }
}
