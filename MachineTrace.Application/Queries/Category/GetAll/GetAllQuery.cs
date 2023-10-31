using MachineTrace.Application.Dto.Category;
using MediatR;

namespace MachineTrace.Application.Queries.Category.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
