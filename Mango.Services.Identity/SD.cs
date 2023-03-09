using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Mango.Services.Identity
{
    //SD-static Details
    public static class SD
    {
        //roles in the application
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        //identity resources 
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Mango","Mango Server"),
                new ApiScope(name:"read",displayName:"read your data."),
                new ApiScope(name:"write",displayName:"write your data."),
                new ApiScope(name:"delete",displayName:"Delete your data.")
            };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId= "client",
                ClientSecrets={new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes={"read","write","profile"}
            },
            new Client
            {
                ClientId= "mango",
                ClientSecrets={new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "http://localhost:44338" },
                PostLogoutRedirectUris={ "http://localhost:44338/signout-callback-oidc" },
                AllowedScopes= new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                }
            }
        };
    }
}
