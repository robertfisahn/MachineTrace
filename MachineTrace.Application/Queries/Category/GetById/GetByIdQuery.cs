using MachineTrace.Application.Dto.Category;
using MediatR;


namespace MachineTrace.Application.Queries.Category.GetById
{
    public class GetByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
