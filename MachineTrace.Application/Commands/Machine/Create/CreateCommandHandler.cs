using AutoMapper;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.Machine.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;
        public CreateCommandHandler(IMachineRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateCommand command, CancellationToken cancellationToken)
        {
            var machine = _mapper.Map<Domain.Entities.Machine>(command);
            await _machineRepository.Create(machine);
        }
    }
}
