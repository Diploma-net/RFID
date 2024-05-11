using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Equip.Command;
using RFLOT.Application.Equip.Models;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.Equip.CommandHandler;

public class CheckEquipCommandHandler : IRequestHandler<CheckEquipCommand, EquipInfo>
{
    private readonly EquipDbContext _dbContext;

    public CheckEquipCommandHandler(EquipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EquipInfo> Handle(CheckEquipCommand command, CancellationToken cancellationToken)
    {
        var equip =
            await _dbContext.Equips.FirstOrDefaultAsync(e => e.Id == command.RfId,
                cancellationToken) ?? throw new ApplicationException("АСО не найдено");

        return new EquipInfo
        {
            LastStatus = equip.GetStatusString(),
            Name = equip.Name,
            Space = equip.Space ?? "АСО не привязано к определенному месту",
            Type = equip.GetTypeString()
        };
    }
}