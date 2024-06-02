using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Gateway.DTO.Equip;

public class CheckEquipDto
{
    public string IdEquip { get; set; }
    public Status StatusEquip { get; set; }
    public Guid IdZone { get; set; }
    public Guid IdReport { get; set; }
    public Guid IdUser { get; set; }
}