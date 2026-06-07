namespace RoleWeb.DAL.Entities;

public class GroupParameterEntity
{
    public required string GUID { get; set; } // Уникальный идентификатор группового параметра
    
    public required string Name { get; set; } // Наименование группового параметра
    
    public required string NameJSON { get; set; } // Наименование JSON группового параметра

    public bool IsGroup { get; set; } // Признак "ЭтоГруппа" группового параметра
    
    public GroupParameterEntity? Parent { get; set; } // Родитель группового параметра
}