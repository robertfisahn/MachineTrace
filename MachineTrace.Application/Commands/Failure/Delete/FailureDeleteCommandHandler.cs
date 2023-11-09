using MachineTrace.Infrastructure.Repositories;
using MediatR;

namespace MachineTrace.Application.Commands.Failure.Delete
{
    public class FailureDeleteCommandHandler : IRequestHandler<FailureDeleteCommand>
    {
        private readonly IFailureRepository _failureRepository;

        public FailureDeleteCommandHandler(IFailureRepository failureRepository)
        {
            _failureRepository = failureRepository;
        }
        public async Task Handle(FailureDeleteCommand request, CancellationToken cancellationToken)
        {
            await _failureRepository.DeleteById(request.Id);
        }
    }
}
