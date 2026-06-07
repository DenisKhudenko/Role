using Microsoft.EntityFrameworkCore;
using RoleWeb.DAL.Entities;

namespace RoleWeb.DAL;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}

    public DbSet<UserEntity> User => Set<UserEntity>();
    public DbSet<UserGroupEntity> UserGroup => Set<UserGroupEntity>();
    public DbSet<GroupParameterEntity> GroupParameter => Set<GroupParameterEntity>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }    
}