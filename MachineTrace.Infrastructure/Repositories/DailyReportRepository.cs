using MachineTrace.Domain.Entities;
using MachineTrace.Domain.Intefaces;
using MachineTrace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MachineTrace.Infrastructure.Repositories
{
    public class DailyReportRepository : IDailyReportRepository
    {
        private readonly MachineTraceDbContext _context;
        public DailyReportRepository(MachineTraceDbContext context)
        {
            _context = context;
        }
        public async Task Create(DailyReport report)
        {
            _context.DailyReports.Add(report);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DailyReport>> GetAll()
            => await _context.DailyReports.Include(d => d.Machine).ToListAsync();

        public async Task<DailyReport> GetById(int id)
            => await _context.DailyReports.Include(d => d.Machine).SingleOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<DailyReport>> GetByMachine(int machineId)
            => await _context.DailyReports.Where(d => d.MachineId == machineId).ToListAsync();

        public async Task DeleteById(int id)
        {
            var report = new DailyReport { Id = id };
            _context.DailyReports.Attach(report);
            _context.DailyReports.Remove(report);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
