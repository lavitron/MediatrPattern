using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TokenEntity.Entity;

namespace TokenDAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasAlternateKey(p => p.IdentityNumber);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(100).IsRequired();
            builder.Property(p => p.IdentityNumber).HasMaxLength(11).IsFixedLength().IsRequired();
            builder.Property(p => p.Gender).HasMaxLength(1).IsFixedLength().IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.PasswordSalt).IsRequired();
        }
    }
}