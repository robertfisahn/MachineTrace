using MachineTrace.Domain.Entities;
using MachineTrace.Domain.Intefaces;
using MachineTrace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MachineTrace.Infrastructure.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly MachineTraceDbContext _context;

        public MachineRepository(MachineTraceDbContext context)
        {
            _context = context;
        }

        public async Task Create(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Machine>> GetAll()
            => await _context.Machines.Include(m => m.Category).ToListAsync();

        public async Task<Machine?> GetByIdAsync(int id)
            => await _context.Machines.Include(c => c.Category).SingleOrDefaultAsync(x => x.Id == id);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public async Task Delete(int id)
        {
            var machine = new Machine { Id = id };
            _context.Machines.Attach(machine);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
        }
    }
}
