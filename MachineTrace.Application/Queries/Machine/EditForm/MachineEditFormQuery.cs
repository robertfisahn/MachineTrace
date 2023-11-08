using MachineTrace.Application.Dto.Category;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Enums;
using MediatR;

namespace MachineTrace.Application.Queries.Machine.EditForm
{
    public class MachineEditFormQuery : IRequest<MachineDtoEdit>
    {
        public int Id { get; set; }

        public MachineEditFormQuery(int id)
        {
            Id = id;
        }
    }
}
