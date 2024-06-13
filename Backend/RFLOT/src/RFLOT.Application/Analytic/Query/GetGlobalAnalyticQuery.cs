using MediatR;
using RFLOT.Application.Analytic.Model;

namespace RFLOT.Application.Analytic.Query;

public class GetGlobalAnalyticQuery : IRequest<GlobalAnalyticModel>
{
}