using MachineTrace.Domain.Entities;
using MachineTrace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MachineTrace.Infrastructure.Repositories
{
    public class FailureRepository : IFailureRepository
    {
        private readonly MachineTraceDbContext _context;

        public FailureRepository(MachineTraceDbContext context)
        {
            _context = context;
        }

        public async Task Save()
            => await _context.SaveChangesAsync();
        public async Task Create(Failure failure)
        {
            _context.Failures.Add(failure);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Failure>> GetAll()
            => await _context.Failures.Include(f => f.Machine).ToListAsync();

        public async Task<Failure> GetById(int id)
            => await _context.Failures.Include(f => f.Machine).SingleOrDefaultAsync(f => f.Id == id);

        public async Task DeleteById(int id)
        {
            var failure = new Failure { Id = id };
            _context.Failures.Attach(failure);
            _context.Failures.Remove(failure);
            await _context.SaveChangesAsync();
        }

    }
}
