using AutoMapper;
using MachineTrace.Application.Dto.DailyReport;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, DailyReportDtoDetails>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }
        public async Task<DailyReportDtoDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _dailyReportRepository.GetById(request.Id);
            var dto = _mapper.Map<DailyReportDtoDetails>(report);
            if(request.FromMachine != null)
            {
                dto.FromMachine = request.FromMachine;
            }
            return dto;
        }
    }
}
