using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Commands.DailyReport.Create
{
    public class DailyReportCreateCommand : DailyReportDtoCreate, IRequest
    {
    }
}
