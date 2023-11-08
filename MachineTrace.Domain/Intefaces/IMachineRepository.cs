namespace MachineTrace.Domain.Intefaces
{
    public interface IMachineRepository
    {
        Task<IEnumerable<Domain.Entities.Machine>> GetAll();
        Task<Domain.Entities.Machine?> GetByIdAsync(int id);
        Task Create(Domain.Entities.Machine machine);
        Task Save();
        Task Delete(int id);
    }
}
