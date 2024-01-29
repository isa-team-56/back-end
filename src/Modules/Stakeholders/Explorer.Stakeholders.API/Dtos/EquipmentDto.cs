using Type = Explorer.Stakeholders.API.Enums.EquipmentEnums.Type;

namespace Explorer.Stakeholders.API.Dtos;

public class EquipmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Type Type { get; set; }
    public int Price { get; set; }
    public int CompanyId { get; set; }

}