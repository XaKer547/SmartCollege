using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using System.Security.Claims;

namespace SmartCollege.SSO.IdentityProfiles;

public class AccountIdentityProfile(UserManager<AccountIdentity> userManager, IUserClaimsPrincipalFactory<AccountIdentity> claimsFactory) : ProfileService<AccountIdentity>(userManager, claimsFactory)
{
    protected override async Task GetProfileDataAsync(ProfileDataRequestContext context, AccountIdentity user)
    {
        var principal = await GetUserClaimsAsync(user);

        var claims = (ClaimsIdentity)principal.Identity!;

        claims.AddClaim(new Claim("verified", user.Verified.ToString()));

        context.AddRequestedClaims(principal.Claims);
    }
}