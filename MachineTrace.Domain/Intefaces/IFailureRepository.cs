using MachineTrace.Domain.Entities;

namespace MachineTrace.Infrastructure.Repositories
{
    public interface IFailureRepository
    {
        Task<IEnumerable<Failure>> GetAll();
        Task Create(Failure failure);
        Task<Failure> GetById(int id);
        Task<IEnumerable<Failure>> GetByMachine(int id);
        Task Save();
        Task DeleteById(int id);
    }
}