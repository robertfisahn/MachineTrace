using MachineTrace.Domain.Enums;

namespace MachineTrace.Application.Dto.DailyReport
{
    public class DailyReportDtoDetails
    {
        public int Id { get; set; }
        public int Mth { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string MachineCode { get; set; } = default!;
        public int? MachineId { get; set; }
        public int? FromMachine { get; set; }
    }
}
