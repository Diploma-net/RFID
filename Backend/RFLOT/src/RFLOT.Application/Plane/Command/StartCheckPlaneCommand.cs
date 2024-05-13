using MediatR;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Application.Plane.Command;

public class StartCheckPlaneCommand : IRequest<Guid>
{
    public StartCheckPlaneCommand(string idPlane, Guid idUser, ReportType typeCheck)
    {
        IdPlane = idPlane;
        IdUser = idUser;
        TypeCheck = typeCheck;
    }

    public string IdPlane { get; }
    public Guid IdUser { get; }
    public ReportType TypeCheck { get; }
}