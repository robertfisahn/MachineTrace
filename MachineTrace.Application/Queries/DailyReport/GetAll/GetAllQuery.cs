using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<DailyReportDto>>
    {
    }
}
