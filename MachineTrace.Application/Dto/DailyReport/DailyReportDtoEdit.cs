using MachineTrace.Domain.Enums;

namespace MachineTrace.Application.Dto.DailyReport
{
    public class DailyReportDtoEdit
    {
        public int Id { get; set; }
        public int Mth { get; set; }
        public MaintenanceStatus Status { get; set; }
        public int MachineId { get; set; }
        public IEnumerable<string>? MaintenanceStatuses { get; set; }
    }
}
