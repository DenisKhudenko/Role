namespace RoleWeb.DAL.Entities;

public class UserEntity
{
    public required string GUID { get; set; } // Уникальный идентификатор пользователя
    
    public required string Name { get; set; } // Наименование
    
    public string Email { get; set; } // E-mail и другие поля по необходимости
    
    public List<UserGroupEntity> UserGroups { get; set; } // Список ссылок на группы пользователей
}