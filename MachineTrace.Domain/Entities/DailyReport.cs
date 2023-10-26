using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Domain.Entities
{
    public class DailyReport
    {
        public int Id { get; set; }
        public int Mth { get; set; }
        public enum MaintenanceStatus
        {
            Done,
            NotDone
        }
        public MaintenanceStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; } = default!;
    }
}
