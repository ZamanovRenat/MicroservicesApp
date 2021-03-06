using System.Collections.Generic;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MicroservicesApp.Services.Identity
{
    public static class SD
    {
        //Константы ролей
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        /// <summary>
        /// Ресурсы IdentityServer, для защиты от несанкционированного доступа
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// Области видимости
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> {
                new ApiScope("mango", "Mango Server"),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };
        /// <summary>
        /// Объект клиента сервера, клиент часть ПО который запрашивает токкен у IdentityServer для аутентификации
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },

                new Client
                {
                    ClientId="mango",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:5002/signout-callback-oidc" },
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "mango"
                    }
                },

            };
    }
}
