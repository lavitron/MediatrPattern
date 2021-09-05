using System.Collections.Generic;
using Core.Entity.Concrete;

namespace TokenEntity.Entity
{
    public class User : CoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public char Gender { get; set; }
        public string IdentityNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}