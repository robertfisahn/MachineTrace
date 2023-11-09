using MachineTrace.Application.Dto.Failure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Commands.Failure.Create
{
    public class FailureCreateCommand : FailureDtoCreate, IRequest
    {
    }
}
