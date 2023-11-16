using AutoMapper;
using MachineTrace.Application.Dto.DailyReport;
using MachineTrace.Domain.Enums;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.EditForm
{
    public class EditFormQueryHandler : IRequestHandler<EditFormQuery, DailyReportDtoEdit>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IMapper _mapper;

        public EditFormQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }
        public async Task<DailyReportDtoEdit> Handle(EditFormQuery request, CancellationToken cancellationToken)
        {
            var report = await _dailyReportRepository.GetById(request.Id);
            var form = _mapper.Map<DailyReportDtoEdit>(report);

            form.MaintenanceStatuses = Enum.GetNames(typeof(MaintenanceStatus));
            return form;
        }
    }
}
