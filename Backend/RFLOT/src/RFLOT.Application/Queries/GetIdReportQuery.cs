using MediatR;

namespace RFLOT.Application.Queries;

public class GetIdReportQuery : IRequest<string>
{
    public GetIdReportQuery(string idPlane, string typeCheck, string fullNameChecker)
    {
        IdPlane = idPlane;
        TypeCheck = typeCheck;
        FullNameChecker = fullNameChecker;
    }

    public string IdPlane { get;  }
    public string TypeCheck { get;  }
    public string FullNameChecker { get; }
}