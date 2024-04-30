using CollegeManagementSystem.Domain.Specializations;

namespace CollegeManagementSystem.Application.Repositories.Specializations;

public interface ISpecializationReadOnlyRepository
{
    Task<Specialization> GetSpecializationAsync(SpecializationId specializationId);
}
