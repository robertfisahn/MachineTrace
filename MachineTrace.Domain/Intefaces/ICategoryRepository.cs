namespace MachineTrace.Domain.Intefaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Domain.Entities.Category>> GetAll();
        Task Create(Domain.Entities.Category category);
        Task<Domain.Entities.Category?> GetByName(string name);
        Task<Domain.Entities.Category?> GetById(int id);
        Task Save();
    }
}
