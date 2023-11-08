using MachineTrace.Application.Dto.Machine;
using MediatR;

namespace MachineTrace.Application.Queries.Machine.GetById
{
    public class GetByIdQuery : IRequest<MachineDto>
    {
        public int Id { get; set; }
        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
