using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Commands.Failure.Edit
{
    public class FailureEditCommand : FailureDtoEdit, IRequest
    {
    }
}
