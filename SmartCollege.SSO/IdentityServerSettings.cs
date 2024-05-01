using Duende.IdentityServer.Models;
using Newtonsoft.Json;

namespace SmartCollage.SSO;

public sealed record IdentityServerSettings
{
    public IdentityServerSettings()
    {
        var test = new Client
        {
            ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("4ccd8311a94ec24e7db7eaeb10521ffa2ba98df49503db2e1ea3a000beabbabe".Sha512())
            },

            // scopes that client has access to
            AllowedScopes = { "api1" }
        };

        var r = JsonConvert.SerializeObject(test);
    }


    public IReadOnlyCollection<ApiScope> ApiScopes { get; init; }
    public IReadOnlyCollection<ApiResource> ApiResources { get; init; }

    public IReadOnlyCollection<Client> Clients { get; init; }

    public IReadOnlyCollection<IdentityResource> IdentityResources =>
        [
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
        ];
}
