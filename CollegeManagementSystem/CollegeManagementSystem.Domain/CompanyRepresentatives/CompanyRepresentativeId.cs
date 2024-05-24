using SharedKernel;

namespace CollegeManagementSystem.Domain.CompanyRepresentatives;

public sealed class CompanyRepresentativeId : EntityId
{
    public CompanyRepresentativeId(Guid id) : base(id) { }
    public CompanyRepresentativeId() : base() { }
}
