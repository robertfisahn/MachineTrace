using MachineTrace.Application.Dto.Failure;
using MachineTrace.Domain.Enums;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.CreateForm
{
    public class FailureCreateFormQueryHandler : IRequestHandler<FailureCreateFormQuery, FailureDtoCreate>
    {
        public Task<FailureDtoCreate> Handle(FailureCreateFormQuery request, CancellationToken cancellationToken)
        {
            var failurePriorities = Enum.GetNames(typeof(FailurePriority));
            var form = new FailureDtoCreate
            {
                MachineId = request.MachineId,
                FailurePriorities = failurePriorities
            };
            return Task.FromResult(form);
        }
    }
}
