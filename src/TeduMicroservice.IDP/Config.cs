using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace TeduMicroservice.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource()
            {
                Name = "role",
                UserClaims = new List<string> {"role"},
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ("tedu_api_read", "Read Scope"),
            new ("tedu_api_write", "Write Scope"),
        };
    
    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("tedu_api", "Tedu API")
            {
                Scopes = new List<string> {"tedu_api_read", "tedu_api_write"},
                UserClaims = new List<string> {"role"}
            },
            new ApiResource("tedu_api_read_only", "Tedu API")
            {
                Scopes = new List<string> {"tedu_api_read"},
            }
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new()
            {
                ClientName = "Tedu Swagger Client",
                ClientId = "tedu_swagger",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
                AccessTokenLifetime = 60 * 60 * 2,
                RedirectUris = new List<string>
                {
                    "http://localhost:5001/swagger/oauth2-redirect.html"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "http://localhost:5001/swagger/oauth2-redirect.html"
                },
                AllowedCorsOrigins = new List<string>
                {
                    "http://localhost:5001/"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "tedu_api_read",
                    "tedu_api_read"
                }
            }
        };
}