namespace MachineTrace.Application.Dto.Machine
{
    public class MachineDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int TimeToService { get; set; }
        public string Condition { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string CategoryName { get; set; } = default!;
        public string? ImagePath { get; set; }
    }
}