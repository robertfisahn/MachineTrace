using AutoMapper;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.Machine.Delete
{
    public class MachineDeleteCommandHandler : IRequestHandler<MachineDeleteCommand>
    {
        private readonly IMachineRepository _machineRepository;

        public MachineDeleteCommandHandler(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }
        public async Task Handle(MachineDeleteCommand request, CancellationToken cancellationToken)
        {
            await _machineRepository.Delete(request.Id);
        }
    }
}
