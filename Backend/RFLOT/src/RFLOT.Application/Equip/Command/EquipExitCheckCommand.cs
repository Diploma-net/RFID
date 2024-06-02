using MediatR;
using RFLOT.Application.Equip.Models;

namespace RFLOT.Application.Equip.Command;

public class EquipExitCheckCommand : IRequest<EquipInfo?>
{
    public EquipExitCheckCommand(string idEquip)
    {
        IdEquip = idEquip;
    }

    public string IdEquip { get; }
}