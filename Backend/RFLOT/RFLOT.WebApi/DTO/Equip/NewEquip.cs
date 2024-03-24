using Type = RFLOT.Domain.Type;

namespace RFLOT.WebApi.DTO.Equip;

public class NewEquip
{
    public record Request(string Id, Guid ZoneId, string PlanePlace, string Name, Type Type, DateTimeOffset DateTimeEnd);
}
