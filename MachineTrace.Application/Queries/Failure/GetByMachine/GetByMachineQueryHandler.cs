using AutoMapper;
using MachineTrace.Application.Dto.Failure;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.GetByMachine
{
    public class GetByMachineQueryHandler : IRequestHandler<GetByMachineQuery, IEnumerable<FailureDto>>
    {
        private readonly IFailureRepository _failureRepository;
        private readonly IMapper _mapper;

        public GetByMachineQueryHandler(IFailureRepository failureRepository, IMapper mapper)
        {
            _failureRepository = failureRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FailureDto>> Handle(GetByMachineQuery request, CancellationToken cancellationToken)
        {
            var failures = await _failureRepository.GetByMachine(request.MachineId);
            var dtos = _mapper.Map<IEnumerable<FailureDto>>(failures);
            return dtos;
        }
    }
}
