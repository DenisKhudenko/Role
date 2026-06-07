using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoleWeb.DAL.Entities;

namespace RoleWeb.Dal.Configurations;

public class GroupParameterConfiguration : IEntityTypeConfiguration<GroupParameterEntity>
{
    public void Configure(EntityTypeBuilder<GroupParameterEntity> builder)
    {
        builder.ToTable("userGroups");

        builder.HasKey(x => x.GUID);
        builder.Property(x => x.GUID).HasColumnName("guid");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150).HasColumnName("name");
        
        builder.Property(x => x.NameJSON).IsRequired().HasColumnName("name_json");
    }
}
