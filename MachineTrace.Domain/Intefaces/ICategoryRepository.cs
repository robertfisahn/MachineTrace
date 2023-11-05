using MachineTrace.Domain.Entities;

namespace MachineTrace.Domain.Intefaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Domain.Entities.Category>> GetAll();
        Task Create(Domain.Entities.Category category);
        Task<Domain.Entities.Category?> GetByNameAsync(string name);
        Task<Domain.Entities.Category?> GetByIdAsync(int id);
        Category? GetById(int id);
        Category? GetByName(string name);
        Task Save();
        Task Delete(Category category);
    }
}
