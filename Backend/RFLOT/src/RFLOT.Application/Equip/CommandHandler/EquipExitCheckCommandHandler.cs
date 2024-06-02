using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Equip.Command;
using RFLOT.Application.Equip.Models;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.Equip.CommandHandler;

public class EquipExitCheckCommandHandler : IRequestHandler<EquipExitCheckCommand, EquipInfo>
{
    private readonly EquipDbContext _equipDbContext;

    public EquipExitCheckCommandHandler(EquipDbContext equipDbContext)
    {
        _equipDbContext = equipDbContext;
    }

    public async Task<EquipInfo?> Handle(EquipExitCheckCommand command, CancellationToken cancellationToken)
    {
        var equip = await _equipDbContext.Equips.FirstOrDefaultAsync(e => e.Id == command.IdEquip,
            cancellationToken: cancellationToken);
        if (equip is null)
        {
            return null;
        }
        else
        {
            return new EquipInfo
            {
                LastStatus = equip.LastStatus,
                Type = equip.Type,
                Name = equip.Name,
                Space = equip.Space
            };
        }
    }
}