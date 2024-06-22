namespace SmartCollege.SSO.Shared.Contracts
{
    public interface ICreateRepresentativeOfTheCompanyAccountContract 
    {
        string Email { get; }

        string FullName { get; }

        string Phone { get; }

        string Company { get; }
    }
}
