using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartCollage.SSO.Data;

public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : IdentityDbContext<IdentityUser>(options)
{

}
