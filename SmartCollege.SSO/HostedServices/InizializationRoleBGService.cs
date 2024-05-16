using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Data;

namespace SmartCollege.SSO.HostedServices
{
    public class InizializationRoleBGService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public InizializationRoleBGService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<AuthorizationDbContext>();

                var roleExists = await dbContext.Roles.AnyAsync(cancellationToken: cancellationToken);
                if (!roleExists)
                {
                    await dbContext.Roles.AddRangeAsync(
                        new IdentityRole(Shared.Roles.Teacher.ToString()),
                        new IdentityRole(Shared.Roles.Student.ToString()),
                        new IdentityRole(Shared.Roles.HeadOfDepartment.ToString()),
                        new IdentityRole(Shared.Roles.ClassroomTeacher.ToString()),
                        new IdentityRole(Shared.Roles.RepresentativeOfTheCompany.ToString()));

                    await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
