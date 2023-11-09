using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Commands.Failure.Delete
{
    public class FailureDeleteCommand : FailureDto , IRequest
    {
    }
}
