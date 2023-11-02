using MachineTrace.Application.Dto.Category;
using MediatR;

namespace MachineTrace.Application.Queries.Category.GetByName
{
    public class GetByNameQuery : IRequest<CategoryDto>
    {
        public string Name { get; set; }

        public GetByNameQuery(string name)
        {
            Name = name;
        }
    }
}
