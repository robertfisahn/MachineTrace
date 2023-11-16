using AutoMapper;
using MachineTrace.Application.Dto.DailyReport;
using MachineTrace.Domain.Enums;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.CreateForm
{
    public class CreateFormQueryHandler : IRequestHandler<CreateFormQuery, DailyReportDtoCreate>
    {
        public Task<DailyReportDtoCreate> Handle(CreateFormQuery request, CancellationToken cancellationToken)
        {
            var maintenanceStatuses = Enum.GetNames(typeof(MaintenanceStatus));
            var dailyReport = new DailyReportDtoCreate{
                MachineId = request.MachineId,
                MaintenanceStatuses = maintenanceStatuses,
            };
            return Task.FromResult(dailyReport);
        }
    }
}
