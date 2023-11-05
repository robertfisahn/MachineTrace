using MachineTrace.Application.Dto.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Commands.Category.Delete
{
    public class DeleteCommand : CategoryDto, IRequest
    {
    }
}
