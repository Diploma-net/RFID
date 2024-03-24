using AutoMapper;
using RFLOT.Application.Commands;
using RFLOT.Domain;
using RFLOT.Domain.Equip;
using RFLOT.WebApi.DTO;
using RFLOT.WebApi.DTO.Equip;
using Type = RFLOT.Domain.Type;

namespace RFLOT.WebApi.MappingProfiles;

public class EquipMappingProfile : Profile
{
    public EquipMappingProfile()
    {
        CreateMap<AddNewEquipCommand, Equip>()
            .ForMember(d => d.LastStatus, opt => opt.MapFrom(s => Status.Ok))
            .ForMember(d => d.DateTimeStart, opt => opt.MapFrom(s => DateTimeOffset.Now))
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
            .ForMember(d => d.RfId, opt => opt.MapFrom(s =>s.Id))
            .ForMember(d => d.ZoneId, opt => opt.MapFrom(s =>s.ZoneId))
            .ForMember(d => d.Name, opt => opt.MapFrom(s =>s.Name))
            .ForMember(d => d.PlanePlace, opt => opt.MapFrom(s =>s.PlanePlace))
            .ForMember(d => d.DateTimeEnd, opt => opt.MapFrom(s =>s.DateTimeEnd));
        CreateMap<NewEquip.Request, AddNewEquipCommand>();
    }
}