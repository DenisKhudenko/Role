using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoleWeb.DAL.Entities;

namespace RoleWeb.Dal.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.GUID);
        builder.Property(x => x.GUID).HasColumnName("guid");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150).HasColumnName("name");
        builder.Property(x => x.Email).HasMaxLength(500).HasColumnName("email");
        
        builder.HasMany(x => x.UserGroups)
            .WithMany(x => x.Users)
            .UsingEntity(name => name.ToTable("user_user_groups"));
    }
}
