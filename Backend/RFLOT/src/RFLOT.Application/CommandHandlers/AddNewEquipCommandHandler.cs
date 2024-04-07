using AutoMapper;
using MediatR;
using RFLOT.Application.Commands;
using RFLOT.Domain;
using RFLOT.Domain.Equip;
using RFLOT.Infrastructure.Equip;
using Type = RFLOT.Domain.Equip.Type;

namespace RFLOT.Application.CommandHandlers;

public class AddNewEquipCommandHandler : IRequestHandler<AddNewEquipCommand>
{
    private readonly RfidDbContext _dbContext;

    public AddNewEquipCommandHandler(RfidDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddNewEquipCommand command, CancellationToken cancellationToken)
    { 
        /*var newEquip = new Equip(command.Id, command.)
       await _dbContext.Equips.AddAsync(newEquip, cancellationToken);
       await _dbContext.SaveChangesAsync(cancellationToken);*/
    }
}