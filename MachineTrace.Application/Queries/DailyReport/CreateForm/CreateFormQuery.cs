using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.CreateForm
{
    public class CreateFormQuery : IRequest<DailyReportDtoCreate>
    {
        public int MachineId { get; set; }

        public CreateFormQuery(int machineId)
        {
            MachineId = machineId;
        }
    }
}
