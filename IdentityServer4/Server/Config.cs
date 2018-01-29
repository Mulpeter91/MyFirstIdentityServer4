using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Test;

namespace Server
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client1",

                    //no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    //secret for authentication
                    ClientSecrets =
                    {
                        new Secret("KHJ34K-34NKJ2-34N2J-NJ3N42".Sha256())
                    },

                    //scopes that client has access to
                    AllowedScopes = {"api1"}
                },
                new Client
                {
                    ClientId = "client2",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("J4234NKE-3423-4N3KJN4K23-343".Sha256())
                    },
                    AllowedScopes = {"api1"}
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Diaz",
                    Password = "12345"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Mulpeter",
                    Password = "54321"
                }
            };
        }
    }
}
