using Core.Entity.Concrete;

namespace TokenEntity.Entity
{
    public class UserRole : CoreEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User UserFk { get; set; }
        public int RoleId { get; set; }
        public Role RoleFk { get; set; }
    }
}