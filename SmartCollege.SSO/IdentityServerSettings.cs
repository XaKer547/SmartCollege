using Duende.IdentityServer.Models;

namespace SmartCollage.SSO;

public sealed record IdentityServerSettings
{
    public IReadOnlyCollection<ApiScope> ApiScopes { get; init; }
    public IReadOnlyCollection<ApiResource> ApiResources { get; init; }

    public IReadOnlyCollection<Client> Clients { get; init; }

    public IReadOnlyCollection<IdentityResource> IdentityResources =>
        [
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("verify", ["verified"])
        ];
}
