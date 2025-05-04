using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Marvin.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", "Your role(s)", new [] {"role"} )
        };

    public static IEnumerable<ApiResource> ApiResources =>
                new ApiResource[]
        {
            new ApiResource("imagegalleryapi", "Image Gallery API")
            {
                Scopes = { "imagegalleryapi.fullaccess" },
                UserClaims = { "role" }
            },
            new ApiResource("country", "Country API")
            {
                Scopes = { "country.fullaccess" },
                UserClaims = { "role" }
            }
        };


    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
            new ApiScope("imagegalleryapi.fullaccess"),
            };

    public static IEnumerable<Client> Clients =>
         new Client[]
            {
                new Client()
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                 //   AccessTokenType = AccessTokenType.Reference,
                 //   AllowOfflineAccess = true,
                  //  UpdateAccessTokenClaimsOnRefresh = true,
                  //  AccessTokenLifetime = 120,
                    // AuthorizationCodeLifetime = ...
                    // IdentityTokenLifetime = ...
                    RedirectUris =
                    {
                        "https://localhost:7184/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7184/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                       "roles",
                        "imagegalleryapi.fullaccess",
                        ////"imagegalleryapi.fullaccess",
                        //"imagegalleryapi.read",
                        //"imagegalleryapi.write",
                        //"country"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }, 
                     RequireConsent = true
                }
            };

}