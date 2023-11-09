using MachineTrace.Domain.Enums;

namespace MachineTrace.Application.Dto.Failure
{
    public class FailureDto
    {
        public int Id { get; set; }
        public int Mth { get; set; }
        public FailurePriority Priority { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string MachineCode { get; set; } = default!;
    }
}
