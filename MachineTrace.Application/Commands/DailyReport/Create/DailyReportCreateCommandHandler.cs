using AutoMapper;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.DailyReport.Create
{
    public class DailyReportCreateCommandHandler : IRequestHandler<DailyReportCreateCommand>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IMapper _mapper;

        public DailyReportCreateCommandHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }
        public async Task Handle(DailyReportCreateCommand request, CancellationToken cancellationToken)
        {
            var report = _mapper.Map<Domain.Entities.DailyReport>(request);
            await _dailyReportRepository.Create(report);
        }
    }
}
