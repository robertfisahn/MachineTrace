using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.GetByMachine
{
    public class GetByMachineQuery : IRequest<IEnumerable<FailureDto>>
    {
        public int MachineId { get; set; }

        public GetByMachineQuery(int machineId)
        {
            MachineId = machineId;
        }
    }
}
