using MachineTrace.Application.Dto.Machine;
using MediatR;

namespace MachineTrace.Application.Commands.Machine.Delete
{
    public class MachineDeleteCommand : MachineDto, IRequest
    {
    }
}
