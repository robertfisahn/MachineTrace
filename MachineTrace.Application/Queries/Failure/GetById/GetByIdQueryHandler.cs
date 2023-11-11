using AutoMapper;
using MachineTrace.Application.Dto.Failure;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, FailureDtoDetails>
    {
        private readonly IFailureRepository _failureRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IFailureRepository failureRepository, IMapper mapper)
        {
            _failureRepository = failureRepository;
            _mapper = mapper;
        }
        public async Task<FailureDtoDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var failure = await _failureRepository.GetById(request.Id);
            var dto = _mapper.Map<FailureDtoDetails>(failure);
            if(request.FromMachine != null)
            {
                dto.FromMachine = request.FromMachine;
            }
            return dto;
        }
    }
}
