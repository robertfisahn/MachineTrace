using MachineTrace.Domain.Enums;

namespace MachineTrace.Application.Dto.DailyReport
{
    public class DailyReportDto
    {
        public int Id { get; set; }
        public int Mth { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string MachineCode { get; set; } = default!;
    }
}
