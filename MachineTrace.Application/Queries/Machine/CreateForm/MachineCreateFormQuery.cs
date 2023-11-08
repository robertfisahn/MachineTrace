using MachineTrace.Application.Dto.Machine;
using MediatR;

namespace MachineTrace.Application.Queries.Machine.CreateForm
{
    public class MachineCreateFormQuery : IRequest<MachineDtoCreate>
    {
    }
}
