using MachineTrace.Application.Dto.Machine;
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
