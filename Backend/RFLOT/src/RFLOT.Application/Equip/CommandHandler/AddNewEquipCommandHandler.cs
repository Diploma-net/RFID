using MediatR;
using RFLOT.Application.Equip.Command;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.Equip.CommandHandler;

public class AddNewEquipCommandHandler : IRequestHandler<AddNewEquipCommand>
{
    private readonly EquipDbContext _dbContext;

    public AddNewEquipCommandHandler(EquipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddNewEquipCommand command, CancellationToken cancellationToken)
    {
        var newEquip = new Equip(command.Id);
       await _dbContext.Equips
           .AddAsync(newEquip, cancellationToken);
       await _dbContext.SaveChangesAsync(cancellationToken);
    }
}