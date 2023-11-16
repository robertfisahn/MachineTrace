using AutoMapper;
using MachineTrace.Application.Dto.DailyReport;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<DailyReportDto>>
    {
        private readonly IDailyReportRepository _dailyRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyRepository = dailyReportRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DailyReportDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var reports = await _dailyRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<DailyReportDto>>(reports);
            return dtos;

        }
    }
}
