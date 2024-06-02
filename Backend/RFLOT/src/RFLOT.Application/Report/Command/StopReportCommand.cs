using MediatR;

namespace RFLOT.Application.Report.Command;

public class StopReportCommand : IRequest
{
    public StopReportCommand(Guid idReport)
    {
        IdReport = idReport;
    }

    public Guid IdReport { get;  }
}