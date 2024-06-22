namespace SmartCollege.SSO.Shared.Contracts
{
    public interface IUpdateBlockingRepresentativeOfTheCompanyAccountContract
    {
        string Email { get; }

        bool IsBlocked { get; }
    }
}
