namespace ProjectManagementSystem.Domain.Services;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    IProjectManagementSystemRepository Repository { get; }
}
