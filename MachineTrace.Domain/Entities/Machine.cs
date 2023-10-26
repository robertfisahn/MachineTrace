using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Domain.Entities
{
    public class Machine
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int Mth { get; set; }
        public int ServiceInterval { get; set; }
        public int TimeToService => ServiceInterval - (Mth % ServiceInterval);
        public enum MachineCondition
        {
            Efficient,
            Damaged
        }
        public MachineCondition Condition { get; set; }
        public enum MachineStatus
        {
            Waiting,
            Working
        }
        public MachineStatus Status { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
        public virtual List<Failure>? Failures { get; set; }
        public virtual List<DailyReport>? DailyReports { get; set; }
        public virtual List<ServiceReport>? ServiceReports { get; set; }
    }
}
