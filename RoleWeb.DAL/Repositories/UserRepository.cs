using Microsoft.EntityFrameworkCore;
using RoleWeb.DAL.Entities;
using RoleWeb.DAL.Repositories.Interfaces;

namespace RoleWeb.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDBContext _context;

    public UserRepository(AppDBContext context) { _context = context; }
    
    public async Task<IReadOnlyCollection<UserEntity>> GetList()
        => await _context.User.ToListAsync();

    public async Task<UserEntity?> GetById(string guid)
        => await _context.User.FindAsync(guid);

    public async Task<UserEntity> Create(UserEntity entity)
    {
        _context.User.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<UserEntity?> Update(UserEntity entity)
    {
        var existing = await _context.User.FindAsync(entity.GUID);
        if (existing is null) return null;

        existing.Name = entity.Name;
        existing.Email = entity.Email;
        existing.UserGroups = entity.UserGroups;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> Delete(string guid)
    {
        var entity = await _context.User.FindAsync(guid);
        if (entity is null) return false;

        _context.User.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}