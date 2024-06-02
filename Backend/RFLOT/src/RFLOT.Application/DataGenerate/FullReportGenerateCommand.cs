using MediatR;

namespace RFLOT.Application.DataGenerate;

public class FullReportGenerateCommand : IRequest<List<Guid>>
{
    public FullReportGenerateCommand(int count)
    {
        CountGenerate = count;
    }

    public int CountGenerate { get; }

}