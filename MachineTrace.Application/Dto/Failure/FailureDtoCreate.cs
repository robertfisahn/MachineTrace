using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Enums;

namespace MachineTrace.Application.Dto.Failure
{
    public class FailureDtoCreate
    {
        public string Description { get; set; } = default!;
        public int Mth { get; set; }
        public FailurePriority Priority { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int MachineId { get; set; }
        public IEnumerable<MachineDtoShort>? Machines { get; set; }
        public IEnumerable<string>? FailurePriorities { get; set; }
    }
}
