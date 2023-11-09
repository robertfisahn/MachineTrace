using MachineTrace.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Dto.Failure
{
    public class FailureDtoDetails
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public int Mth { get; set; }
        public FailurePriority Priority { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string MachineCode { get; set; } = default!;
    }
}
