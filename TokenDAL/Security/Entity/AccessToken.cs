using System;

namespace TokenDAL.Security.Entity
{
    public record AccessToken
    {
        public string Token { get; init; }
        public DateTime Expiration { get; init; }
    }
}