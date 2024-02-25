namespace RFLOT.Domain;

public class Equip
{
    public string RfId { get; set; }
    public Guid IdZone { get; set; }
    public string PlanePlace { get; set; }
    public string Name { get; set; }
    public Type Type { get; set; }
    public DateTimeOffset DateTimeStart { get; set; }
    public DateTimeOffset DateTimeEnd { get; set; }
    public Status LastStatus { get; set; }

}

