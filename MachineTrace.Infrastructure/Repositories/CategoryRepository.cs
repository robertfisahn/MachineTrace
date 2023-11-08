using MachineTrace.Domain.Intefaces;
using MachineTrace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MachineTrace.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly MachineTraceDbContext _context;
        public CategoryRepository(MachineTraceDbContext context)
        {
            _context = context;    
        }
        public async Task Create(Domain.Entities.Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Domain.Entities.Category>> GetAll()
            => await _context.Categories.ToListAsync();
        public Task<Domain.Entities.Category?> GetByIdAsync(int id)
            => _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        public Task<Domain.Entities.Category?> GetByNameAsync(string name)
            => _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }     
        public async Task Delete(Domain.Entities.Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        public Domain.Entities.Category? GetById(int id)
            => _context.Categories.FirstOrDefault(c => c.Id == id);
        public Domain.Entities.Category? GetByName(string name)
            => _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
    }
}
