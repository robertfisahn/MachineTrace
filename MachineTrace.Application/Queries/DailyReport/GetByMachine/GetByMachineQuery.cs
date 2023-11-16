using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.GetByMachine
{
    public class GetByMachineQuery : IRequest<IEnumerable<DailyReportDtoDetails>>
    {
        public int MachineId { get; set; }

        public GetByMachineQuery(int machineId)
        {
            MachineId = machineId;
        }
    }
}
