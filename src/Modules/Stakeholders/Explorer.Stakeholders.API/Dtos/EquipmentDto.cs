namespace Explorer.Stakeholders.API.Dtos;

public class EquipmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Type { get; set; }
    public int Price { get; set; }
    public int CompanyId { get; set; }

}