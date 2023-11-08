using MachineTrace.Application.Dto.Machine;
using MediatR;
namespace MachineTrace.Application.Queries.Machine.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<MachineDto>>
    {
    }
}
