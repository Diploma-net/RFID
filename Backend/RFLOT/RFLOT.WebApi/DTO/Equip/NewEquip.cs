namespace RFLOT.WebApi.DTO;

public class NewEquip
{
    public record Request(string Id, Guid ZoneId, string PlanePlace, string Name, int Type, DateTimeOffset DateTimeEnd);
}