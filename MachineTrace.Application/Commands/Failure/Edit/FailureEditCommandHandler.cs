using AutoMapper;
using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Commands.Failure.Edit
{
    public class FailureEditCommandHandler : IRequestHandler<FailureEditCommand>
    {
        private readonly IFailureRepository _failureRepository;
        private readonly IMapper _mapper;

        public FailureEditCommandHandler(IFailureRepository failureRepository, IMapper mapper)
        {
            _failureRepository = failureRepository;
            _mapper = mapper;
        }
        public async Task Handle(FailureEditCommand request, CancellationToken cancellationToken)
        {
            var machine = await _failureRepository.GetById(request.Id);
            _mapper.Map(request, machine);
            await _failureRepository.Save();
        }
    }
}
