using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Commands.Failure.Create
{
    public class FailureCreateCommand : FailureDtoCreate, IRequest
    {
    }
}
