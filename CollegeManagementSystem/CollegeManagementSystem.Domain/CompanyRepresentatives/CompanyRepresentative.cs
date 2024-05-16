using CollegeManagementSystem.Domain.Users;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.CompanyRepresentatives;

public sealed class CompanyRepresentative : User<CompanyRepresentativeId>
{
    private CompanyRepresentative()
    {
        Id = new CompanyRepresentativeId();
    }

    public string CompanyName { get; private set; }
    public string PhoneNumber { get; private set; }

    public static CompanyRepresentative Create(string firstName, string middlename, string lastName, string companyName, string phoneNumber, string email)
    {
        var companyRepresentative = new CompanyRepresentative()
        {
            FirstName = firstName,
            MiddleName = middlename,
            LastName = lastName,
            CompanyName = companyName,
            PhoneNumber = phoneNumber,
            Email = email,
        };

        return companyRepresentative;
    }

    public void Update(string firstName, string middlename, string lastName, string companyName, string phoneNumber)
    {
        FirstName = firstName;
        MiddleName = middlename;
        LastName = lastName;
        CompanyName = companyName;
        PhoneNumber = phoneNumber;
    }
    public void Update(string password)
    {
        UpdateAccount(password, [Roles.RepresentativeOfTheCompany]);
    }
    public void Delete()
    {
        DeleteAccount();
    }
}