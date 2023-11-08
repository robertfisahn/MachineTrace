using MachineTrace.Application.Dto.Machine;
using MediatR;

namespace MachineTrace.Application.Commands.Machine.Edit
{
    public class MachineEditCommand : MachineDtoEdit, IRequest
    {
    }
}
