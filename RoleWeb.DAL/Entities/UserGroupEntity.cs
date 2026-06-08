namespace RoleWeb.DAL.Entities;

public class UserGroupEntity
{
    public required string GUID { get; set; } // Уникальный идентификатор группы пользователей
    
    public required string Name { get; set; } // Наименование группы пользователей
    
    public List<GroupParameterEntity> Parameters { get; set; } // Список ссылок на групповые параметры
    
    public List<UserEntity> Users { get; set; } // Список пользователей
}