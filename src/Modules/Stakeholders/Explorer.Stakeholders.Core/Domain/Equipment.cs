using Explorer.BuildingBlocks.Core.Domain;
using Type = Explorer.Stakeholders.API.Enums.EquipmentEnums.Type;

namespace Explorer.Stakeholders.Core.Domain;

public class Equipment : Entity
{
    public string Name { get; init; }

    public string Description { get; init; }

    public Type Type { get; init; }

    public int Price { get; init; }

   
    public List<int> CompanyIds { get; init; }


    public Equipment(string name, string description,Type type,int price,List<int> companyIds)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
        Name = name;
        Description = description;
        Type = type;
        Price = price;
        CompanyIds = companyIds ?? new List<int>();

    }
}