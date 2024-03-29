using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Test;

namespace IdentityProvider
{
    public class TestUsers
    {
        public static List<TestUser> Users =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                    Username = "John",
                    Password = "JohnPassword",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "John"),
                        new Claim("family_name", "Doe")
                    }
                },
                new TestUser
                {
                    SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
                    Username = "Jane",
                    Password = "JanePassword",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Jane"),
                        new Claim("family_name", "Doe")
                    }
                }
            };
    }
}