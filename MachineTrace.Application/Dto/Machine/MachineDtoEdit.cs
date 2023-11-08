using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Dto.Machine
{
    public class MachineDtoEdit
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int Mth { get; set; }
        public int ServiceInterval { get; set; }
        [Required]
        public MachineCondition Condition { get; set; }
        [Required]
        public MachineStatus Status { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryDto>? Categories { get; set; }
        public IEnumerable<string>? AvailableConditions { get; set; }
        public IEnumerable<string>? AvailableStatuses { get; set; }
    }
}
