using AutoMapper;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Commands.Failure.Create
{
    public class FailureCreateCommandHandler : IRequestHandler<FailureCreateCommand>
    {
        private readonly IFailureRepository _failureRepository;
        private readonly IMapper _mapper;

        public FailureCreateCommandHandler(IFailureRepository failureRepository, IMapper mapper)
        {
            _failureRepository = failureRepository;
            _mapper = mapper;
        }
        public async Task Handle(FailureCreateCommand request, CancellationToken cancellationToken)
        {

            var failure = _mapper.Map<Domain.Entities.Failure>(request);
            await _failureRepository.Create(failure);
        }
    }
}
