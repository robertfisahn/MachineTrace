using MachineTrace.Application.Dto.Category;
using MediatR;

namespace MachineTrace.Application.Commands.Category.Delete
{
    public class DeleteCommand : CategoryDto, IRequest
    {
    }
}
