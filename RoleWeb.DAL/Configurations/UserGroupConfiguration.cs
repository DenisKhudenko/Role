using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoleWeb.DAL.Entities;

namespace RoleWeb.Dal.Configurations;

public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroupEntity>
{
    public void Configure(EntityTypeBuilder<UserGroupEntity> builder)
    {
        builder.ToTable("user_groups");

        builder.HasKey(x => x.GUID);
        builder.Property(x => x.GUID).HasColumnName("guid");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150).HasColumnName("name");
        
        builder.HasMany(x => x.Parameters)
            .WithMany(x => x.UserGroups)
            .UsingEntity(name => name.ToTable("user_groups_parameters"));
    }
}
