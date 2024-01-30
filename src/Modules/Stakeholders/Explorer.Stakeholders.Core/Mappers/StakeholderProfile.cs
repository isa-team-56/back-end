using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.Users;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<FollowerDto, Follower>().ReverseMap();
        CreateMap<NotificationDto, Notification>().ReverseMap();
        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<CompanyDto, Company>().ReverseMap();
    }
}