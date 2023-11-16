using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.DailyReport.Delete
{
    public class DailyReportDeleteCommandHandler : IRequestHandler<DailyReportDeleteCommand>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        public DailyReportDeleteCommandHandler(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }
        public async Task Handle(DailyReportDeleteCommand request, CancellationToken cancellationToken)
        {
            await _dailyReportRepository.DeleteById(request.Id);
        }
    }
}
