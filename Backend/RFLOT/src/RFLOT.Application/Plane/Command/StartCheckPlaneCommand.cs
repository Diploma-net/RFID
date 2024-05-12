using MediatR;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Application.Plane.Command;

public class StartCheckPlaneCommand : IRequest<Guid>
{
    public StartCheckPlaneCommand(Guid idPlane, Guid idUser, ReportType typeCheck)
    {
        IdPlane = idPlane;
        IdUser = idUser;
        TypeCheck = typeCheck;
    }

    public Guid IdPlane { get; }
    public Guid IdUser { get; }
    public ReportType TypeCheck { get; }
}