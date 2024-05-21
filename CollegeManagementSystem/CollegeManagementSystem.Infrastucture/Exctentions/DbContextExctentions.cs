using CollegeManagementSystem.Infrastucture.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollegeManagementSystem.Infrastucture.Exctentions
{
    public static class DbContextExctentions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CollegeManagementSystemDbContext>(options =>
            {
                #if true
                    options.UseSqlServer(configuration.GetConnectionString("LocalConnection"));

#else
                                options.UseNpgsql(configuration.GetConnectionString("PgLocalConnection"), b => b.MigrationsAssembly("CollegeManagementSystem.Infrastucture.Postgres"));
#endif

            });
        }
    }
}
