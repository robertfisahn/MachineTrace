using MachineTrace.Domain.Enums;

namespace MachineTrace.Application.Dto.DailyReport
{
    public class DailyReportDtoCreate
    {
        public int Mth { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int MachineId { get; set; }
        public IEnumerable<string>? MaintenanceStatuses { get; set; }
    }
}
