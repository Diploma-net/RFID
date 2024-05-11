using Type = RFLOT.Domain.Equip.ValueObjects.Type;

namespace RFLOT.Gateway.DTO.Equip;

public class NewEquip
{
    public record Request(
        string Id,
        Guid ZoneId,
        string PlanePlace,
        string Name,
        Type Type,
        DateTimeOffset DateTimeEnd);
}