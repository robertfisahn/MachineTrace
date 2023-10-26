using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Domain.Entities
{
    public class Failure
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public int Mth { get; set; }
        public enum FailurePriority
        {
            Current,
            Important
        }
        public FailurePriority Priority { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; } = default!;
    }
}
