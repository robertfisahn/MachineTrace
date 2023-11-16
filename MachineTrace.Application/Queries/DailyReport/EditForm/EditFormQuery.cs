using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.EditForm
{
    public class EditFormQuery : IRequest<DailyReportDtoEdit>
    {
        public int Id { get; set; }

        public EditFormQuery(int id)
        {
            Id = id;
        }
    }
}
