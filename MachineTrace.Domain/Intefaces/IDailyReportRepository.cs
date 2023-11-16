using MachineTrace.Domain.Entities;

namespace MachineTrace.Domain.Intefaces
{
    public interface IDailyReportRepository
    {
        Task Create(DailyReport report);
        Task<IEnumerable<DailyReport>> GetAll();
        Task<DailyReport> GetById(int id);
        Task<IEnumerable<DailyReport>> GetByMachine(int machineId);
        Task DeleteById(int id);
        Task Save();
    }
}
