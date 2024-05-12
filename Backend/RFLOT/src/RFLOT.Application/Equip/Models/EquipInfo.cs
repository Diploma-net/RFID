using RFLOT.Domain.Equip.ValueObjects;
using Type = RFLOT.Domain.Equip.ValueObjects.Type;

namespace RFLOT.Application.Equip.Models;

public class EquipInfo
{
    public string Name { get; set; }
    public string? Space { get; set; }
    public Type Type { get; set; }
    public Status LastStatus { get; set; }
}