using RoleWeb.DAL.Entities;

namespace RoleWeb.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<UserEntity>> GetList();

        Task<UserEntity?> GetById(string guid);

        Task<UserEntity> Create(UserEntity entity);

        Task<UserEntity?> Update(UserEntity entity);

        Task<bool> Delete(string guid);
    }

}
