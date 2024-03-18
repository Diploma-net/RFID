using AutoMapper;
using MediatR;
using RFLOT.Application.Commands;
using RFLOT.Domain.Equip;
using RFLOT.Infrastructure.Contexts;

namespace RFLOT.Application.CommandHandlers;

public class AddNewEquipCommandHander : IRequestHandler<AddNewEquipCommand>
{
    private readonly RfidContext _context;
    private readonly IMapper _mapper;

    public AddNewEquipCommandHander(RfidContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(AddNewEquipCommand command, CancellationToken cancellationToken)
    {
        var equip = _mapper.Map<Equip>(command);
       await _context.Equips.AddAsync(_mapper.Map<Equip>(command), cancellationToken);
    }
}