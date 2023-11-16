using AutoMapper;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.DailyReport.Edit
{
    public class DailyReportEditCommandHandler : IRequestHandler<DailyReportEditCommand>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IMapper _mapper;

        public DailyReportEditCommandHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }
        public async Task Handle(DailyReportEditCommand request, CancellationToken cancellationToken)
        {
            var report = await _dailyReportRepository.GetById(request.Id);
            _mapper.Map(request, report);
            await _dailyReportRepository.Save();
        }
    }
}
