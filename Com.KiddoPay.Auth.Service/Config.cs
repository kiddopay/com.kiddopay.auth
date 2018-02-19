using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.KiddoPay.Auth.Service
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("com.kiddopay.payment", "KiddoPay Payment API")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "postman.cc",
                    ClientName = "Postman client w/ client credential",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "com.kiddopay.payment" }
                },

                new Client
                {
                    ClientId = "postman.ro",
                    ClientName = "Postman client w/ resource owner password",
                    // require user to logged in, use the resource owner password for authentication
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris ={
                        "https://www.getpostman.com/oauth2/callback"
                    },
                    // scopes that client has access to
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "com.kiddopay.payment"
                    }
                },

                new Client
                {
                    ClientId = "com.kiddopay.clients.mvc.frontend",
                    ClientName = "Frontend MVC Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:5200/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5200/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "com.kiddopay.payment"
                    },
                    AllowOfflineAccess = true
                },

                new Client
                {
                    ClientId = "com.kiddopay.clients.js.frontend",
                    ClientName = "Frontend JS Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser=true,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:4200/login/callback" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "com.kiddopay.payment"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}
