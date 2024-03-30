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
    private readonly RfidContext _context;

    public AddNewEquipCommandHandler(RfidContext context)
    {
        _context = context;
    }

    public async Task Handle(AddNewEquipCommand command, CancellationToken cancellationToken)
    { 
        /*var newEquip = new Equip(command.Id, command.)
       await _context.Equips.AddAsync(newEquip, cancellationToken);
       await _context.SaveChangesAsync(cancellationToken);*/
    }
}