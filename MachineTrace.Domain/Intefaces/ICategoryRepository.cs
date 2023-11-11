namespace MachineTrace.Domain.Intefaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Domain.Entities.Category>> GetAll();
        Task Create(Domain.Entities.Category category);
        Task<Domain.Entities.Category?> GetByIdAsync(int id);
        Domain.Entities.Category? GetById(int id);
        Domain.Entities.Category? GetByName(string name);
        Task Save();
        Task Delete(Domain.Entities.Category category);
    }
}
