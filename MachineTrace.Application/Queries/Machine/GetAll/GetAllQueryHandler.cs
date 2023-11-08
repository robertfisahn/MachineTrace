using AutoMapper;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.Machine.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<MachineDto>>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IMachineRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MachineDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var machines = await _machineRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<MachineDto>>(machines);
            return dtos;
        }
    }
}
