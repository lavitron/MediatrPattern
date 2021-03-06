using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TokenEntity.Entity;

namespace TokenDAL.Context
{
    public class TokenDbContext : DbContext, ITokenDbContext
    {
        public TokenDbContext(DbContextOptions<TokenDbContext> options) : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}