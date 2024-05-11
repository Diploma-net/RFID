using MediatR;

namespace RFLOT.Application.Report.Query;

public class GetIdReportQuery : IRequest<Guid>
{
    public GetIdReportQuery(string idPlane, string typeCheck, string fullNameChecker)
    {
        IdPlane = idPlane;
        TypeCheck = typeCheck;
        FullNameChecker = fullNameChecker;
    }

    public string IdPlane { get; }
    public string TypeCheck { get; }
    public string FullNameChecker { get; }
}