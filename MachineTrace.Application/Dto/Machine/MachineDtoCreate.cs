using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MachineTrace.Application.Dto.Machine
{
    public class MachineDtoCreate
    {
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
