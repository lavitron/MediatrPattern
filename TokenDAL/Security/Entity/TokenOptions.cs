namespace TokenDAL.Security.Entity
{
    public record TokenOptions
    {
        public string Audience { get; init; }
        public string Issuer { get; init; }
        public int AccessTokenExpiration { get; init; }
        public string SecurityKey { get; init; }
    }
}