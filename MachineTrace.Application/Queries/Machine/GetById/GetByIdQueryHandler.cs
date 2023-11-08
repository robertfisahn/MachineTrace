using AutoMapper;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.Machine.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, MachineDto>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IMachineRepository machine, IMapper mapper)
        {
            _machineRepository = machine;
            _mapper = mapper;
        }

        public async Task<MachineDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var machine = await _machineRepository.GetByIdAsync(request.Id);
            var dto = _mapper.Map<MachineDto>(machine);
            return dto;
        }
    }
}
