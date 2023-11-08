using MachineTrace.Application.Dto.Machine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Commands.Machine.Create
{
    public class CreateCommand : MachineDtoCreate, IRequest
    {
    }
}
