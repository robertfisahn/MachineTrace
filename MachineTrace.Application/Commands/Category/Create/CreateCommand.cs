using MachineTrace.Application.Dto.Category;
using MediatR;

namespace MachineTrace.Application.Commands.Category.Create
{
    public class CreateCommand : CategoryDto, IRequest
    {
    }
}
