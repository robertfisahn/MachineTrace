using AutoMapper;
using MachineTrace.Application.Dto.DailyReport;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.GetByMachine
{
    public class GetByMachineQueryHandler : IRequestHandler<GetByMachineQuery, IEnumerable<DailyReportDtoDetails>>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IMapper _mapper;

        public GetByMachineQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DailyReportDtoDetails>> Handle(GetByMachineQuery request, CancellationToken cancellationToken)
        {
            var reports = await _dailyReportRepository.GetByMachine(request.MachineId);
            var dtos = _mapper.Map<IEnumerable<DailyReportDtoDetails>>(reports);
            return dtos;
        }
    }
}
