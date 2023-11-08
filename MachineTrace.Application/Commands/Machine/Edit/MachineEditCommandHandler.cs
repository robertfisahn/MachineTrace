using AutoMapper;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.Machine.Edit
{
    public class MachineEditCommandHandler : IRequestHandler<MachineEditCommand>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;

        public MachineEditCommandHandler(IMachineRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }
        public async Task Handle(MachineEditCommand request, CancellationToken cancellationToken)
        {
            var machine = await _machineRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, machine);
            await _machineRepository.Save();
        }
    }
}
