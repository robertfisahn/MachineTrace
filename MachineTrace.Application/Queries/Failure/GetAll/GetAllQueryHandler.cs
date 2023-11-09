using AutoMapper;
using MachineTrace.Application.Dto.Failure;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<FailureDto>>
    {
        private readonly IFailureRepository _failureRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IFailureRepository failureRepository, IMapper mapper)
        {
            _failureRepository = failureRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FailureDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var failures = await _failureRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<FailureDto>>(failures);
            return dtos;
        }
    }
}
