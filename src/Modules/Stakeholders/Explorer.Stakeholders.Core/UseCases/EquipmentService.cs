using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.UseCases;

public class EquipmentService : CrudService<EquipmentDto, Equipment>, IEquipmentService
{
    public EquipmentService(ICrudRepository<Equipment> repository, IMapper mapper) : base(repository, mapper) {}
}