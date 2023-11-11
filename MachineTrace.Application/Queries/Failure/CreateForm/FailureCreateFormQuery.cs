using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.CreateForm
{
    public class FailureCreateFormQuery : IRequest<FailureDtoCreate>
    {
        public int MachineId { get; set; }

        public FailureCreateFormQuery(int machineId)
        {
            MachineId = machineId;
        }
    }
}
