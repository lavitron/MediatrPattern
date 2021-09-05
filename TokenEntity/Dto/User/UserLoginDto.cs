using Core.Entity.Abstract;

namespace TokenEntity.Dto.User
{
    public record UserLoginDto : IDto
    {
        public string IdentityNumber { get; init; }
        public string Password { get; init; }
    }
}