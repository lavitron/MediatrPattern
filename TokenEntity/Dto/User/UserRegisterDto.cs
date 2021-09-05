using Core.Entity.Abstract;

namespace TokenEntity.Dto.User
{
    public record UserRegisterDto : IDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string IdentityNumber { get; init; }
        public char Gender { get; init; }
        public string Password { get; init; }
        public int UserRole { get; init; }
    }
}