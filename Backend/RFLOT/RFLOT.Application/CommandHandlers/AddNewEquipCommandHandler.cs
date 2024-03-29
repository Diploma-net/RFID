using AutoMapper;
using MediatR;
using RFLOT.Application.Commands;
using RFLOT.Domain;
using RFLOT.Domain.Equip;
using RFLOT.Infrastructure.Contexts;
using Type = RFLOT.Domain.Type;

namespace RFLOT.Application.CommandHandlers;

public class AddNewEquipCommandHandler : IRequestHandler<AddNewEquipCommand>
{
    private readonly RfidContext _context;
    private readonly IMapper _mapper;

    public AddNewEquipCommandHandler(RfidContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(AddNewEquipCommand command, CancellationToken cancellationToken)
    { 
        var newEquip = new Equip(command.Id, command.ZoneId, command.PlanePlace, command.Name, command.Type , DateTimeOffset.Now, command.DateTimeEnd);
       await _context.Equips.AddAsync(newEquip, cancellationToken);
       await _context.SaveChangesAsync(cancellationToken);
    }
}