using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TokenEntity.Entity;

namespace TokenDAL.Context
{
    public interface ITokenDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        Task<int> SaveChangesAsync();
    }
}