using AutoMapper;
using MachineTrace.Application.Dto.Failure;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Enums;
using MachineTrace.Domain.Intefaces;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.EditForm
{
    public class FailureEditFormQueryHandler : IRequestHandler<FailureEditFormQuery, FailureDtoEdit>
    {
        private readonly IFailureRepository _failureRepository;
        private readonly IMapper _mapper;
        private readonly IMachineRepository _machineRepository;

        public FailureEditFormQueryHandler(IFailureRepository failureRepository, IMapper mapper, IMachineRepository machineRepository)
        {
            _failureRepository = failureRepository;
            _mapper = mapper;
            _machineRepository = machineRepository;
        }
        public async Task<FailureDtoEdit> Handle(FailureEditFormQuery request, CancellationToken cancellationToken)
        {
            var failure = await _failureRepository.GetById(request.Id);
            var editForm = _mapper.Map<FailureDtoEdit>(failure);
            var machines = await _machineRepository.GetAll();

            editForm.FailurePriorities = Enum.GetNames(typeof(FailurePriority));
            editForm.Machines = _mapper.Map<IEnumerable<MachineDtoShort>>(machines);
            return editForm;
            
        }
    }
}
