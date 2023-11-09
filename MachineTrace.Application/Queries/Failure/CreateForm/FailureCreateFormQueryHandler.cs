using AutoMapper;
using MachineTrace.Application.Dto.Failure;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Enums;
using MachineTrace.Domain.Intefaces;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.CreateForm
{
    public class FailureCreateFormQueryHandler : IRequestHandler<FailureCreateFormQuery, FailureDtoCreate>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;

        public FailureCreateFormQueryHandler(IMachineRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }
        public async Task<FailureDtoCreate> Handle(FailureCreateFormQuery request, CancellationToken cancellationToken)
        {
            var machines = await _machineRepository.GetAll();
            var dtosMachines = _mapper.Map<IEnumerable<MachineDtoShort>>(machines);
            var failurePriorities = Enum.GetNames(typeof(FailurePriority));
            var form = new FailureDtoCreate
            {
                Machines = dtosMachines,
                FailurePriorities = failurePriorities
            };
            return form;

        }
    }
}
