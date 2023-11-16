using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Commands.DailyReport.Delete
{
    public class DailyReportDeleteCommand : DailyReportDto, IRequest
    {
    }
}
