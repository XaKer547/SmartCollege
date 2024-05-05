using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Data.Entities;

namespace SmartCollage.SSO.Data;

public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : IdentityDbContext<AccountIdentity>(options)
{

}
