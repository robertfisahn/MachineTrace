using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Entities;

namespace MachineTrace.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task Create(CategoryDto category);
    }
}