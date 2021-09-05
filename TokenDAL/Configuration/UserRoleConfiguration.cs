using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TokenEntity.Entity;

namespace TokenDAL.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RoleId).IsRequired();

            builder.HasOne(p => p.RoleFk).WithMany(p => p.UserRoles).HasForeignKey(p => p.RoleId);
            builder.HasOne(p => p.UserFk).WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId);

        }
    }
}